using UnityEngine;
using UnityEngine.Serialization;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "new UpgradeType", menuName = "ScriptableObjects/UpgradeType", order = 1)]
    public class UpgradeType : CanBeBought
    {
        public override void HasBeenBought()
        {
            timesBought++;
        }
        
        public int Level => timesBought;
    }
}
