using System;
using Zenject;

namespace Code.ScenLoader
{
    public class SceneShifter : IDisposable
    {
        private ScenLoader _scenLoader;
        private SceneShifterButtons _sceneShifterButtons;
        private int _countsOfButtons;
        
        [Inject]
        private void Constructor(ScenLoader scenLoader )
        {
            _scenLoader = scenLoader;
        }

        public void SetSceneShifterButtons(SceneShifterButtons sceneShifterButtons)
        {
            _sceneShifterButtons = sceneShifterButtons;
            _countsOfButtons = _sceneShifterButtons._SceneShifterButton.Length;
            InitSceneShifterButtonsSubscribes();
        }

        private void InitSceneShifterButtonsSubscribes()
        {
            for (int i = 0; i < _countsOfButtons; i++)
            {
                _sceneShifterButtons._SceneShifterButton[i].Button.onClick.AddListener(() =>
                {
                    LoadScen(_scenLoader, _sceneShifterButtons, i - 1);
                });
            }
        }

        private static void LoadScen(ScenLoader scenLoader, SceneShifterButtons sceneShifterButtons, int index)
        {
            scenLoader.LoadScen(sceneShifterButtons._SceneShifterButton[index].ScenIndex,
                sceneShifterButtons._SceneShifterButton[index].Type);
        }

        public void Dispose()
        {
            for (int i = 0; i < _countsOfButtons; i++)
            {
                _sceneShifterButtons._SceneShifterButton[i].Button.onClick.RemoveAllListeners();
            }
        }
    }
}