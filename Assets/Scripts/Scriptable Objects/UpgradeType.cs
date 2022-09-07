using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "newUpgradeType", menuName = "ScriptableObjects/UpgradeType", order = 1)]
    public class UpgradeType : ScriptableObject
    {
        [SerializeField] private int level = 0;
        public int Level
        {
            get => level;
            private set => level = value;
        }
        
        [SerializeField]
        private float baseCost = 1f;
        public float BaseCost
        {
            get => baseCost;
            private set => baseCost = value;
        }
        [SerializeField]
        private float costIncrement = 2;

        public float CostIncrement
        {
            get => costIncrement;
            set => costIncrement = value;
        }
    }
}
