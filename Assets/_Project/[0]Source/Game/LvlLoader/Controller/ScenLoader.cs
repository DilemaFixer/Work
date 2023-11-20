using System;
using System.Collections;
using Code.CoroutineActivator;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.ScenLoader
{
    public class ScenLoader
    {
        private ICoroutineActivator _coroutineActivator;
        private int _indexOfCurrentScen;
        public float ProgresAsyncLoadingScen { get; private set; }

        [Inject]
        public void Constructor(ICoroutineActivator coroutineActivator)
        {
            _coroutineActivator = coroutineActivator;
        }

        public void LoadScen(int scenIndex, ScenLoadingType loadingType)
        {
            if(scenIndex == _indexOfCurrentScen)
                return;
            
            if (scenIndex < 0 && scenIndex > SceneManager.sceneCount)
            {
                throw new IndexOutOfRangeException("Scene does not exist at index: " + scenIndex);
            }
            
            switch (loadingType)
            {
                case ScenLoadingType.Single:
                    LoadScenSingle(scenIndex);
                    break;
                case ScenLoadingType.Additive:
                    LoadScenAdditive(scenIndex);
                    break;
                case ScenLoadingType.Async:
                    LoadScenAsync(scenIndex);
                    break;
                default:
                    _indexOfCurrentScen = scenIndex;
                    break;
            }
        }

        private void LoadScenSingle(int index)
        {
            SceneManager.LoadScene(index, LoadSceneMode.Single);
        }
        
        private void LoadScenAsync(int index)
        {
            _coroutineActivator.ActiveitCoroutine(LoadScenAsyncCorutine(index));
        }

        private void LoadScenAdditive(int index)
        {
            SceneManager.LoadScene(index, LoadSceneMode.Additive);
        }

        private IEnumerator LoadScenAsyncCorutine(int index)
        {
            SceneManager.LoadScene(index, LoadSceneMode.Additive);
            AsyncOperation asyncScenOperation = SceneManager.LoadSceneAsync(index);

            while (!asyncScenOperation.isDone)
            {
                ProgresAsyncLoadingScen = Mathf.Clamp01(asyncScenOperation.progress / 0.9f);

                yield return null;
            }

            ProgresAsyncLoadingScen = 0;
        }
    }
}