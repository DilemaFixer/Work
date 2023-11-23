using System;
using Code.Wallet;
using UnityEngine;
using Zenject;

namespace Code.Warrior
{

    public class WarriorData : MonoBehaviour
    {
        [SerializeField] private WarriorUpgradeData _upgradeData;
        [SerializeField] private int _lvl;
        
        private int _damage;
        private int _reloadSpeed;
        private int _cashMultiplier;

        public event Action IsMaxUpgrade;

        public int Damage { get; private set; }
        public int ReloadSpeed { get; private set; }
        public int MoneyDrop { get; private set; }

        public int Lvl
        {
            get { return _lvl; }
        }

        public void UpgradeDamage(int amount)
        {
            if (!IsImproves(SkillsType.Damag , Damage))
            {
                return;
            }
            
            Damage += amount;
        }

        public void UpgradeReloadSpeed(int amount)
        {
            if (!IsImproves(SkillsType.ReloadSpeed , ReloadSpeed))
            {
                return;
            }
            
            ReloadSpeed += amount;
        }

        public void UpgradeMoneyDrop(int amount)
        {
            if (!IsImproves(SkillsType.CashMultiplier , MoneyDrop))
            {
                return;
            }
            
            MoneyDrop += amount;
        }


        private bool IsImproves(SkillsType skillsType , int lvl)
        {
            int maxLvl = _upgradeData.GetMaxSkillVeluBySkillType(skillsType);
            if (lvl + 1 > maxLvl)
            {
                return false;
            }

            return true;
        }

        public void ChekIsAllImproves()
        {
            if (IsImproves(SkillsType.CashMultiplier, MoneyDrop) &&
                IsImproves(SkillsType.ReloadSpeed, ReloadSpeed) && IsImproves(SkillsType.Damag, Damage))
            {
                IsMaxUpgrade?.Invoke();
            }
        }
    }
}