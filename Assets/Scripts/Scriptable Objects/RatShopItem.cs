using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "newRatShopItem", menuName = "ScriptableObjects/RatShopItem", order = 3)]
    public class RatShopItem : CanBeBought
    {
        [SerializeField] private int tier = 1;
        [SerializeField] private RatType type;

        public override bool HasBeenBought()
        {
            var ratManager = RatManager.Instance;
            //Allow to buy more rats than allowed. This is to prevent players from getting stuck.
            if (ratManager.SpawnedRats.Count >= ratManager.MaxRats + 2) return false;
            timesBought++;
            ratManager.SpawnRat(type, tier);
            return true;
        }
    }
}