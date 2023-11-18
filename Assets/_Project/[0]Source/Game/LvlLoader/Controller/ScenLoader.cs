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
        public float ProgresAsyncLoadingScen { get; private set; }

        [Inject]
        public void Constructor(ICoroutineActivator coroutineActivator)
        {
            _coroutineActivator = coroutineActivator;
        }

        public void LoadScenAsync(int index)
        {
            _coroutineActivator.StartCoroutine(LoadScenAsyncCorutine(index));
        }

        public void LoadScenAdditive(int index)
        {
            if (index < 0 && index > SceneManager.sceneCount)
            {
                throw new IndexOutOfRangeException("Scene does not exist at index: " + index);
            }

            SceneManager.LoadScene(index, LoadSceneMode.Additive);
        }

        private IEnumerator LoadScenAsyncCorutine(int index)
        {
            if (index < 0 && index > SceneManager.sceneCount)
            {
                throw new IndexOutOfRangeException("Scene does not exist at index: " + index);
            }

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