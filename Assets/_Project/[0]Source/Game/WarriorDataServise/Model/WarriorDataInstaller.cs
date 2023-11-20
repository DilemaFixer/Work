using UnityEngine;
using Zenject;

namespace Code.Data
{
    public class WarriorDataInstaller : MonoInstaller
    {
        [SerializeField] private WarriorData[] _warriorDatas;
        public override void InstallBindings()
        {
            Container.Bind<WarriorDataServise>().FromMethod(() =>
            {
                WarriorDataServise servise = new WarriorDataServise();
                servise.Initialize(_warriorDatas);
                return servise;
            });
        }

        
    }
}