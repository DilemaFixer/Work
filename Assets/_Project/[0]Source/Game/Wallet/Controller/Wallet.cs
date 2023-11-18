using System;
using Code.SaveServise;
using Zenject;

namespace Code.Wallet
{
    public class Wallet : IWallet
    {
        public event Action<int> IsManyChange;
        private int _maney;
        private ISaveServise _saveServise;

        [Inject]
        public void Constructor(ISaveServise saveServise) => _saveServise = saveServise;
        
        public void WithdrawMoney(int amount)
        {
            ChekAmountOnBelowZero(amount);

            if (amount > _maney)
            {
                _maney = 0;
                return;
            }
            else
            {
                _maney -= amount;
            }
            ChangeHandling(amount);
        }

        public void RefillMoney(int amount)
        {
            ChekAmountOnBelowZero(amount);

            _maney += amount;
            ChangeHandling(amount);
        }

        private static void ChekAmountOnBelowZero(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("you're trying to subtract a number below zero");
        }

        private void ChangeHandling(int amount)
        {
            IsManyChange?.Invoke(_maney);
            _saveServise.SaveInt("maney", amount);
        }
    }
}