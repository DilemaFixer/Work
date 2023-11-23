using System;
using Code.Wallet;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Code.Warrior
{
    public class PlayerWarriorUpgrader
    {
        private IWallet _wallet;
        private WarriorData _playerWarriorData;
        private WarriorCollection _collection;
        private PlayerWarrior _playerWarrior;
        private WarriorFactory _factory;

        public event Action<int> OnDamageUpgrade;
        public event Action<int> OnReloadSpeedUpgrade;
        public event Action<int> OnMoneyDropUpgrade;

        [Inject]
        private void Constructor(IWallet wallet, WarriorCollection collection, PlayerWarrior playerWarrior , WarriorFactory factory)
        {
            _wallet = wallet;
            _collection = collection;
            _playerWarrior = playerWarrior;
            _factory = factory;
        }

        public void UpgradeDamage()
        {
            _playerWarrior.Get().UpgradeDamage(1);
        }

        public void UpgradeReloadSpeed()
        {
            _playerWarrior.Get().UpgradeReloadSpeed(1);
        }

        public void UpgradeMoneyDrop()
        {
            _playerWarrior.Get().UpgradeMoneyDrop(1);
        }

        private void UpWarriorLvl()
        {
            int currentLvl = _playerWarrior.Get().Lvl;
            var warrior = InstanciateNewWarrior(currentLvl);
            _playerWarrior.Set(warrior);
        }

        private WarriorData InstanciateNewWarrior(int currentLvl)
        {
            GameObject.Destroy(_playerWarrior.Get().GameObject());
            var warrior = _factory.Create(Quaternion.identity, _collection.GetNexLvl(currentLvl));
            return warrior;
        }
    }
}