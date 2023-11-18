using UnityEngine;
using Zenject;

namespace Code.SaveServise
{
    public class SaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveServise>().To<PlayerPrefsServise>().AsSingle();
        }
    }
}