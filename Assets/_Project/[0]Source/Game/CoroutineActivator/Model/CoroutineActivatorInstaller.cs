using System.Collections;
using Zenject;

namespace Code.CoroutineActivator
{
    public class CoroutineActivatorInstaller : MonoInstaller , ICoroutineActivator
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineActivator>().To<CoroutineActivatorInstaller>().FromInstance(this).AsSingle();
        }

        public void ActiveitCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}