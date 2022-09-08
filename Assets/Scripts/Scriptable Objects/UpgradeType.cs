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
        private decimal baseCost = 1;
        public decimal BaseCost
        {
            get => baseCost;
            private set => baseCost = value;
        }
        [SerializeField]
        private decimal costIncrement = 2;

        public decimal CostIncrement
        {
            get => costIncrement;
            set => costIncrement = value;
        }

        public void NextLevel()
        {
            Level++;
        }
    }
}
