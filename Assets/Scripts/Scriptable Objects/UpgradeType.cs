using UnityEngine;
using UnityEngine.Serialization;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "new UpgradeType", menuName = "ScriptableObjects/UpgradeType", order = 1)]
    public class UpgradeType : CanBeBought
    {
        public override bool HasBeenBought()
        {
            if (timesBought + 1 > buyLimit) return false;
            timesBought++;
            return true;
        }
        
        public int Level => timesBought;
    }
}
