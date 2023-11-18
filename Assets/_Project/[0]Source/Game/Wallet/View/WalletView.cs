using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private IWallet _wallet;
        
        [Inject]
        public void Constract(IWallet wallet)
        {
            _wallet = wallet;
            _wallet.IsManyChange += SetTextVelue;
        }
        
        public void SetTextVelue(int amount)
        {
            _text.text = amount.ToString();
        }
    }
}