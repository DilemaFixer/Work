using Code.SaveServise;
using Zenject;

namespace Code.Warrior
{
    public class PlayerWarrior
    {
        private WarriorData _currentWarrior;
        private ISaveServise _saveServise;

        [Inject]
        private void Constructor(WarriorCollection collection , ISaveServise saveServise)
        {
            _currentWarrior = collection.GetByIndex(0);
            _saveServise = saveServise;
        }
        
        

    }
}