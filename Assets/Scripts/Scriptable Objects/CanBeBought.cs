using System;
using UnityEngine;

namespace Scriptable_Objects
{ 
    public abstract class CanBeBought : ScriptableObject
    {
        [SerializeField] protected int timesBought = 0;
        [SerializeField] protected double baseCost = 20;
        [SerializeField] protected double incrementCostFactor = 1.25;
        
        

        public int TimesBought { get => timesBought; set => timesBought = value; }
        public double BaseCost { get => baseCost; }
        public double IncrementCostFactor { get => incrementCostFactor; }
        public abstract void HasBeenBought();
    }
}