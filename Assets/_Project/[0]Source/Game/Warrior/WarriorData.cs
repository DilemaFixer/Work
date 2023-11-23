using System;
using Code.Wallet;
using UnityEngine;
using Zenject;

namespace Code.Warrior
{

    public class WarriorData : MonoBehaviour
    {
        [SerializeField] private WarriorUpgradeData _upgradeData;
        
        private int _damage;
        private int _reloadSpeed;
        private int _cashMultiplier;
        
        public int Damage { get; private set; }
        public int ReloadSpeed { get; private set; }
        public int CashMultiplier { get; private set; }

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
            if (!IsImproves(SkillsType.CashMultiplier , CashMultiplier))
            {
                return;
            }
            
            CashMultiplier += amount;
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
        
    }
}