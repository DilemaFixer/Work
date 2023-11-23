using Zenject;

namespace Code.Warrior
{
    public class WarriorUpgraderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerWarriorUpgrader>().AsSingle().NonLazy();
            Container.Bind<PlayerWarrior>().AsSingle().NonLazy();
        }
    }
}