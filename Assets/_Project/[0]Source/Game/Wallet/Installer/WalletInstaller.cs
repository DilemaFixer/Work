using Code.Wallet;
using UnityEngine;
using Zenject;

namespace Code.Wallet
{
    public class WalletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IWallet>().To<Wallet>().AsSingle();
        }
    }
}