using Code.Wallet;
using UnityEngine;
using Zenject;

namespace Code.Wallet
{
    public class WalletInstaller : MonoInstaller
    {
        [SerializeField] private WalletView _walletView;

        public override void InstallBindings()
        {
            Container.Bind<IWallet>().To<Wallet>().AsSingle();
            Container.Bind<WalletView>().FromInstance(_walletView).AsSingle();
        }
    }
}