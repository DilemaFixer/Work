using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Warrior
{
    public class PlayerWarriorUpgraderView : MonoBehaviour
    {
        [SerializeField] private Button _damageButtonUpgrad;
        [SerializeField] private Button _reloadSpeeButtonUpgrad;
        [SerializeField] private Button _maneyDropButtonUpgrad;

        [SerializeField] private Slider _damageSlider;
        [SerializeField] private Slider _reloadSpeedSlider;
        [SerializeField] private Slider _maneyDropSleder;
        
        private PlayerWarriorUpgrader _upgrader;

        [Inject]
        private void Constructor(PlayerWarriorUpgrader upgrader)
        {
            _upgrader = upgrader;

            Initialize();
        }

        private void Initialize()
        {
            InitializeButtons();
            InitializeSliders();
        }

        private void InitializeSliders()
        {
            _upgrader.OnDamageUpgrade += (damage) => { _damageSlider.value = damage; };
            _upgrader.OnReloadSpeedUpgrade += (speed) => { _reloadSpeedSlider.value = speed; };
            _upgrader.OnMoneyDropUpgrade += (maneyValue) => { _maneyDropSleder.value = maneyValue; };
        }

        private void InitializeButtons()
        {
            _damageButtonUpgrad.onClick.AddListener(() => { _upgrader.UpgradeDamage(); });
            _reloadSpeeButtonUpgrad.onClick.AddListener(() => { _upgrader.UpgradeReloadSpeed(); });
            _maneyDropButtonUpgrad.onClick.AddListener(() => { _upgrader.UpgradeMoneyDrop(); });
        }
    } 
}