using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private TextMeshProUGUI _diamondText;
        private IWallet _wallet;
        
        [Inject]
        public void Constract(IWallet wallet)
        {
            _wallet = wallet;
            _wallet.IsGoldChange += SetGoldVelue;
            _wallet.IsDiamondsChanges += SetDiamondVelue;
        }
        
        private void SetGoldVelue(int amount)
        {
            _goldText.text = amount.ToString();
        }

        private void SetDiamondVelue(int amount)
        {
            _diamondText.text = amount.ToString();
        }
    }
}