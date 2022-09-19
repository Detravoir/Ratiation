using UnityEngine;

namespace Scriptable_Objects
{
    public class RatShopItem : CanBeBought
    {
        [SerializeField] private int tier = 1;
        [SerializeField] private RatType type;
        public override void HasBeenBought()
        {
            timesBought++;
            //TODO: Spawn a rat of correct type.
        }
    }
}