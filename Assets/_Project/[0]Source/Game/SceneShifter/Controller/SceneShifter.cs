using System;
using Zenject;

namespace Code.ScenLoader
{
    public class SceneShifter : IDisposable
    {
        private ScenLoader _scenLoader;
        private SceneShifterButtons _sceneShifterButtons;
        private int _countOfButtons;
        
        [Inject]
        public void Constructor(ScenLoader scenLoader , SceneShifterButtons sceneShifterButtons)
        {
            _scenLoader = scenLoader;
            _sceneShifterButtons = sceneShifterButtons;
            _countOfButtons = sceneShifterButtons._SceneShifterButton.Length;
            
            for (int i = 0; i < _countOfButtons; i++)
            {
                sceneShifterButtons._SceneShifterButton[i].Button.onClick.AddListener(() =>
                {
                    LoadScen(scenLoader, sceneShifterButtons, i-1);
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
            for (int i = 0; i < _countOfButtons; i++)
            {
                _sceneShifterButtons._SceneShifterButton[i].Button.onClick.RemoveAllListeners();
            }
        }
    }
}