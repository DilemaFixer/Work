using System;
using System.Collections.Generic;
using Code.SaveServise;
using Zenject;

namespace Code.Wallet
{
    // I realize that the interface is useless in this case because most of the time it cannot be changed.
    // But I'm just too lazy to rewrite it =) 
    public class Wallet : IWallet 
    
    {
        public event Action<int> IsGoldChange;
        public event Action<int> IsDiamondsChanges;
        private int _gold;
        private int _diamonds;
        private ISaveServise _saveServise;

        [Inject]
        private void Constructor(ISaveServise saveServise)
        {
            _saveServise = saveServise;

            GetValuesFromeSave();
        }

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

        public bool HasGold(int amount)
        {
            if (CompareNumbers(amount, _gold)) return false;

            return true;
        }

        public bool HasDiamonds(int amount)
        {
            if (CompareNumbers(amount, _diamonds)) return false;

            return true;
        }

        private bool CompareNumbers(int num1, int num2)
        {
            return Comparer<int>.Default.Compare(num1, num2) > 0;
        }
        
        private void GetValuesFromeSave()
        {
            int goldSaveAmount = _saveServise.GetInt(WalletConstants.GoldSaveKey);
            int diamondsSaveAmount = _saveServise.GetInt(WalletConstants.DiamondSaveKey);

            if (goldSaveAmount > 0)
                RefillGold(goldSaveAmount);

            if (diamondsSaveAmount > 0)
                RefillDiamonds(diamondsSaveAmount);
        }

        private static void ChekAmountOnBelowZero(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("you're trying to subtract a number below zero");
        }

        private void ChangeHandling(int amount , ChangeWalletValueType handlingType)
        {
            if (handlingType == ChangeWalletValueType.Gold)
            {
                _saveServise.SaveInt(WalletConstants.GoldSaveKey, amount);
                IsGoldChange?.Invoke(_gold);
            }
            else
            {
                _saveServise.SaveInt(WalletConstants.DiamondSaveKey, amount);
                IsDiamondsChanges?.Invoke(_diamonds);
            }
        }
    }
}