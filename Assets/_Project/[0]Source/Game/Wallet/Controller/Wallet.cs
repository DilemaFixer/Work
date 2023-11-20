using System;
using Code.SaveServise;
using Zenject;

namespace Code.Wallet
{
    public class Wallet : IWallet
    {
        public event Action<int> IsGoldChange;
        public event Action<int> IsDiamondsChanges;
        private int _gold;
        private int _diamonds;
        private ISaveServise _saveServise;

        [Inject]
        public void Constructor(ISaveServise saveServise) => _saveServise = saveServise;
        
        public void WithdrawGold(int amount)
        {
            ChekAmountOnBelowZero(amount);

            if (amount > _gold)
            {
                _gold = 0;
                return;
            }
            else
            {
                _gold -= amount;
            }
            ChangeHandling(amount , ChangeWalletValueType.Gold);
        }

        public void RefillGold(int amount)
        {
            ChekAmountOnBelowZero(amount);

            _gold += amount;
            ChangeHandling(amount , ChangeWalletValueType.Gold);
        }

        public void WithdrawDiamonds(int amount)
        {
            ChekAmountOnBelowZero(amount);

            if (amount > _diamonds)
            {
                _diamonds = 0;
                return;
            }
            else
            {
                _diamonds -= amount;
            }
            ChangeHandling(amount , ChangeWalletValueType.Diamond);
        }

        public void RefillDiamonds(int amount)
        {
            ChekAmountOnBelowZero(amount);
            
            _diamonds += amount;
            ChangeHandling(amount , ChangeWalletValueType.Diamond);
        }

        private static void ChekAmountOnBelowZero(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("you're trying to subtract a number below zero");
        }

        private void ChangeHandling(int amount , ChangeWalletValueType handlingType)
        {
            IsGoldChange?.Invoke(_gold);
            if(handlingType == ChangeWalletValueType.Gold)
                _saveServise.SaveInt("maney", amount);
            else
                _saveServise.SaveInt("diamond", amount);
        }
    }
}