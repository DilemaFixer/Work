using UnityEngine;
using Zenject;

namespace Code.Warrior
{
    public class WarriorFactoryInstaller : MonoInstaller
    {
        [SerializeField] private WarriorFactory _warriorFactory;
        public override void InstallBindings()
        {
            Container.Bind<WarriorFactory>().FromInstance(_warriorFactory).AsSingle();
        }
    }
}