using System;
using UnityEngine;

namespace Scriptable_Objects
{ 
    public abstract class CanBeBought : ScriptableObject
    {
        [SerializeField] protected int timesBought = 0;
        [SerializeField] protected double baseCost = 20;
        [SerializeField] protected double incrementCostFactor = 1.25;

        protected void Awake()
        {
            SaveGameManager.InformationLoaded += LoadTimesBought;
        }
        protected void OnDisable()
        {
            SaveGameManager.InformationLoaded -= LoadTimesBought;
        }
        
        public int TimesBought { get => timesBought; }
        public double BaseCost { get => baseCost; }
        public double IncrementCostFactor { get => incrementCostFactor; }
        public abstract void HasBeenBought();

        protected void LoadTimesBought()
        {
            Debug.Log( name + " Loading times bought");
            timesBought = SaveGameManager.LoadRatShopOrUpgrade(name);
        }
    }
}