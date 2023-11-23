using UnityEngine;
using Zenject;

namespace Code.ScenLoader
{
    public class SceneShifterInstaller : MonoInstaller
    {
        [SerializeField] private SceneShifterButtons _buttons;

        public override void InstallBindings()
        {
            Container.Bind<SceneShifter>().AsSingle().NonLazy();
            Container.Resolve<SceneShifter>().SetSceneShifterButtons(_buttons);
        }
    }
}