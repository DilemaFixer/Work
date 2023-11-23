using System;
using System.Collections.Generic;
using Code.Exceptions;
using UnityEngine;

namespace Code.Warrior
{
    public class WarriorCollection : MonoBehaviour
    {
        [SerializeField] private List<WarriorData> _warriors;
        
        public void Awake() => CheckOnLvlRepeating();

        public int Count
        {
            get { return _warriors.Count; }
        }

        public WarriorData GetByIndex(int lvl)
        {
            CheckIsIndexInRange(lvl);
            return _warriors[lvl];
        }

        public WarriorData GetNexLvl(int currentLvl)
        {
            CheckIsIndexInRange(currentLvl);
            return _warriors[currentLvl + 1];
        }

        private void CheckIsIndexInRange(int lvl)
        {
            if (lvl > _warriors.Count || lvl < 0) throw new ArgumentOutOfRangeException("can not find lvl of warrior :" + lvl);
        }

        private void CheckOnLvlRepeating()
        {
            for (int i = 0; i < _warriors.Count; i++)
            {
                for (int y = 0; y < _warriors.Count; y++)
                {
                    if (_warriors[i].Lvl == _warriors[y].Lvl && i != y)
                    {
                        throw new ValueRepeatsException("lvl of same warrior prefab is repeating");
                    }
                }
            }
        }
    }
}