using System;

namespace Code.Wallet
{
    public interface IWallet
    {
        event Action<int> IsGoldChange;
        event Action<int> IsDiamondsChanges;
        void WithdrawGold(int amount);
        void RefillGold(int amount);
        void WithdrawDiamonds(int amount);
        void RefillDiamonds(int amount);
        bool HasGold(int amount);
        bool HasDiamonds(int amount);
    }
}