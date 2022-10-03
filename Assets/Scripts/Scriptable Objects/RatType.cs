using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "new RatType", menuName = "ScriptableObjects/RatType", order = 2)]
    public class RatType : ScriptableObject
    {
        [FormerlySerializedAs("basePowerPerMinute")] [SerializeField] private double baseCheesePerSecond = 1;
        [SerializeField] private SpriteAtlas ratSpriteAtlas;
        [SerializeField] private int maxTiers = 10;

        public double BaseCheesePerSecond => baseCheesePerSecond;

        public SpriteAtlas RatSpritesAtlas => ratSpriteAtlas;

        public int MaxTiers => maxTiers;
    }
}
