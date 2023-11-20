namespace Code.Data
{
    public class WarriorDataServise 
    { 
        private WarriorData[] _warriorDatas;
        private WarriorData _playerWarrior;

        public void Initialize(WarriorData[] warriorData)
        {
            _warriorDatas = warriorData;
            _playerWarrior = _warriorDatas[0];
        }

        public WarriorData GetWarrior(int lvl)
        {
            return _warriorDatas[lvl];
        }

        public WarriorData GetPlayerWarrior()
        {
            return _playerWarrior;
        } 
        
    }
}