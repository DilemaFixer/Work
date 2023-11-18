using UnityEngine;
using Zenject;

namespace Code.CoroutineActivator
{
    public class CoroutineActivatorInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineActivator _coroutineActivator;
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineActivator>().To<CoroutineActivator>().FromInstance(_coroutineActivator).AsSingle();
        }
    }
}