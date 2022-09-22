using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scriptable_Objects
{ 
    public abstract class CanBeBought : ScriptableObject
    {
        [SerializeField] protected int timesBought = 0;
        [FormerlySerializedAs("limit")] [SerializeField] protected int buyLimit = 0; // 0 is infinite
        [SerializeField] protected double baseCost = 20;
        [SerializeField] protected double incrementCostFactor = 1.25;
        
        public int TimesBought { get => timesBought; set => timesBought = value; }
        public int BuyLimit
        {
            get => buyLimit;
        }
        public double BaseCost { get => baseCost; }
        public double IncrementCostFactor { get => incrementCostFactor; }
        public abstract bool HasBeenBought(); //returns true if success, false if failed.
    }
}