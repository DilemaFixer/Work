using System;
using Code.SaveServise;
using Code.Warrior.Constants;
using Zenject;

namespace Code.Warrior
{
    public class PlayerWarrior : IDisposable
    {
        private WarriorData _currentWarrior;
        private IObjectSaveService<WarriorData> _objSaveServise;

        [Inject]
        private void Constructor(WarriorCollection collection, IObjectSaveService<WarriorData> objSaveServise)
        {
            _currentWarrior = collection.GetByIndex(0);
            this._objSaveServise = objSaveServise;
            _currentWarrior = _objSaveServise.Load(PlayerWarriorConstants.PLAYER_WARRIOR_PATH);
        }

        public WarriorData Get()
        {
            return _currentWarrior;
        }

        public void Set(WarriorData warriorData)
        {
            _currentWarrior = warriorData;
        }

        public void Dispose()
        {
            _objSaveServise.Save(_currentWarrior , PlayerWarriorConstants.PLAYER_WARRIOR_PATH);
        }
    }
}