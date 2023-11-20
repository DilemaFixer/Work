using Code.SaveServise;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.ScenLoader
{
    public class LvlLoderView : MonoBehaviour
    {
        [SerializeField] private Button _battleButton;
        [SerializeField] private ScenLoadingType _loaderBattleScenType;
        [SerializeField] private Button _upgradeButton;
    }
}