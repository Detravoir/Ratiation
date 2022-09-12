using UnityEngine;
using UnityEngine.U2D;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "new RatType", menuName = "ScriptableObjects/RatType", order = 2)]
    public class RatType : ScriptableObject
    {
        [SerializeField] private double basePowerPerMinute = 1;
        [SerializeField] private SpriteAtlas ratSpriteAtlas;
        [SerializeField] private int maxTiers = 10;

        public double BasePowerPerMinute
        {
            get => basePowerPerMinute;
        }
        public SpriteAtlas RatSpritesAtlas
        {
            get => ratSpriteAtlas;
        }
        public int MaxTiers
        {
            get => maxTiers;
        }
    }
}
