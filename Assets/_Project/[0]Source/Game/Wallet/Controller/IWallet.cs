using System;

namespace Code.Wallet
{
    public interface IWallet
    {
        event Action<int> IsManyChange;
        void WithdrawMoney(int amount);
        void RefillMoney(int amount);
    }
}