using System;
using UnityEngine.UI;

namespace Code.ScenLoader
{
    [Serializable]
    public class SceneShifterButton
    {
        public Button Button;
        public ScenLoadingType Type;
        public int ScenIndex;
    }
}