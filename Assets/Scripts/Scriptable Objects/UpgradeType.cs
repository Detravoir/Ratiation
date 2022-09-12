using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "newUpgradeType", menuName = "ScriptableObjects/UpgradeType", order = 1)]
    public class UpgradeType : ScriptableObject
    {
        [SerializeField] private int level = 0;
        
        [SerializeField] private decimal baseCost = 1;
        
        [SerializeField] private decimal costIncrement = 1.25M;
        
        //accessors.
        public int Level { get => level; }
        public decimal BaseCost { get => baseCost; }
        public decimal CostIncrement { get => costIncrement; }

        public void NextLevel()
        {
            level++;
        }
    }
}
