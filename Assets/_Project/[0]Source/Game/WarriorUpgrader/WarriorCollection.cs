using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Warrior
{
    public class WarriorCollection : MonoBehaviour
    {
        [SerializeField] private List<WarriorData> _warriors;

        public int Count
        {
            get { return _warriors.Count; }
        }

        public WarriorData GetByIndex(int lvl)
        {
            if(lvl > _warriors.Count || lvl < 0) throw new IndexOutOfRangeException("index of warrior data out of list range");

            return _warriors[lvl];
        }

        public WarriorData GetNexLvl(int currentLvl)
        {
            if(currentLvl + 1> _warriors.Count || currentLvl < 0) throw new IndexOutOfRangeException("index of warrior data out of list range");

            return _warriors[currentLvl + 1];
        }
        
    }
}