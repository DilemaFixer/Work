using System.ComponentModel;
using Code.Warrior;
using Zenject;

namespace Code.SaveServise
{
    public class SaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IParametersSaveServise>().To<PlayerPrefsParametersSaveServise>().AsSingle();
            Container.Bind<IObjectSaveService<WarriorData>>().To<JsonSavingSystem<WarriorData>>().AsSingle();
        }
    }
}