using Zenject;

namespace Code.ScenLoader
{
    public class SnecLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ScenLoader>().AsSingle().NonLazy();
        }
    }
}