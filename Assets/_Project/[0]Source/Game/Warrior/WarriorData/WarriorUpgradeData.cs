using UnityEngine;

namespace Code.Warrior
{
    [CreateAssetMenu(menuName = "Data/WarriorUpgradeData", fileName = "WarriorData", order = 0)]
    public class WarriorUpgradeData : ScriptableObject
    {
       [field: SerializeField] public int MaxCashMultiplier { get; private set; }
       [field: SerializeField] public int MaxDamage { get; private set; }
       [field: SerializeField] public int MaxAttackSpeed { get; private set; }
       [field: SerializeField] public int AttackSpeedUpgradePrice { get; private set; }
       [field: SerializeField] public int DamageUpgradePrice { get; private set; }
       [field: SerializeField] public int CashMultiplierUpgradePrice { get; private set; }
       public int GetMaxSkillVeluBySkillType(SkillsType skillsType)
       {
           int value = 0;
           switch (skillsType)
           {
               case SkillsType.Damag:
                   value = MaxDamage;
                   break;
               case SkillsType.CashMultiplier:
                   value = MaxCashMultiplier;
                   break;
               case SkillsType.ReloadSpeed:
                   value = MaxAttackSpeed;
                   break;
           }

           return value;
       }
       
       public int GetUpgradePriceBySkillType(SkillsType skillsType)
       {
           int value = 0;
           switch (skillsType)
           {
               case SkillsType.Damag:
                   value = DamageUpgradePrice;
                   break;
               case SkillsType.CashMultiplier:
                   value = CashMultiplierUpgradePrice;
                   break;
               case SkillsType.ReloadSpeed:
                   value = AttackSpeedUpgradePrice;
                   break;
           }

           return value;
       }
    }
}