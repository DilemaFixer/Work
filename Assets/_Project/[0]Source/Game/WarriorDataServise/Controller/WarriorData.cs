using UnityEngine;

namespace Code.Data
{
    [CreateAssetMenu(menuName = "Data/WarriorData", fileName = "WarriorData", order = 0)]
    public class WarriorData : ScriptableObject
    {
        public int CashMultiplier;
        public int Damage;
        public int AttackSpeed;
        public GameObject Prefab;
        public int MaxCashMultiplier;
        public int MaxDamag;
        public int MaxAttackSpeed;
    }
}