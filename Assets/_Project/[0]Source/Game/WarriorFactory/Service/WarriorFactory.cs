using UnityEngine;

namespace Code.Warrior
{
    public class WarriorFactory : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        
        public WarriorData Create( Quaternion quaternion , WarriorData warrior)
        {
            return GameObject.Instantiate(warrior, _spawnPoint.position, quaternion);
        }
    }
}