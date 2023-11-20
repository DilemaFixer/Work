using UnityEngine;
using Zenject;

namespace Code.ScenLoader
{
    public class SceneShifterInstaller : MonoInstaller
    {
        [SerializeField] private SceneShifterButtons _buttons;

        public override void InstallBindings()
        {
            Container.Bind<SceneShifterButtons>().FromInstance(_buttons).AsSingle();
            Container.Bind<SceneShifter>().AsSingle().NonLazy();
        }
    }
}