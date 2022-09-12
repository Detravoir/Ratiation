using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "new UpgradeType", menuName = "ScriptableObjects/UpgradeType", order = 1)]
    public class UpgradeType : ScriptableObject
    {
        [SerializeField] private int level = 0;
        
        [SerializeField] private double baseCost = 1;
        
        [SerializeField] private double costIncrement = 1.25;
        
        //accessors.
        public int Level { get => level; }
        public double BaseCost { get => baseCost; }
        public double CostIncrement { get => costIncrement; }

        public void NextLevel()
        {
            level++;
        }
    }
}
