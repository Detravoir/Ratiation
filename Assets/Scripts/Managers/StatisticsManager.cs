using System;
using UnityEngine;
using UnityEngine.Serialization;

public class StatisticsManager : MonoBehaviour 
{
    [SerializeField] private int highestTierReached = 1;
    [SerializeField] private int totalMerges = 0;
    [SerializeField] private double totalCheeseGained = 0;
    
    public int HighestTierReached => highestTierReached;
    public int TotalMerges => totalMerges;
    public double TotalCheeseGained => totalCheeseGained;

    private void Awake()
    {
        EventManager.OnRatMerge += CheckHighestTier;
        EventManager.OnRatMerge += AddToTotalMerges;
        EventManager.OnCheeseGenerated += AddCheeseToTotal;
    }

    private void OnDisable()
    {
        EventManager.OnRatMerge -= CheckHighestTier;
        EventManager.OnRatMerge -= AddToTotalMerges;
        EventManager.OnCheeseGenerated -= AddCheeseToTotal;
    }

    private void CheckHighestTier(int tier)
    {
        if (tier <= highestTierReached) return;
        highestTierReached = tier;
    }

    private void AddToTotalMerges(int tier)
    {
        totalMerges++;
    }

    public void AddCheeseToTotal(double amount)
    {
        totalCheeseGained += amount;
    }
}