using System;
using Code.Wallet;
using Zenject;

namespace Code.Warrior
{
    public class WarriorUpgrader
    {
        private IWallet _wallet;
        private WarriorCollection _collection;

        public event Action<int> OnDamageUpgrade;
        public event Action<int> OnReloadSpeedUpgrade;
        public event Action<int> OnMoneyDropUpgrade;

        [Inject]
        private void Constructor(IWallet wallet , WarriorCollection collection)
        {
            _wallet = wallet;
            _collection = collection;
        }

        public void Upgrade(SkillsType skillsType)
        {
            
        }
    }
}