using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField] private RatManager ratManager;
    [SerializeField] private int highestTierReached = 1;
    [SerializeField] private int totalMerges = 0;
    [SerializeField] private double totalCheeseGained = 0;
    [SerializeField] private double totalCheesePerSecond;
    
    public int HighestTierReached => highestTierReached;
    public int TotalMerges => totalMerges;
    public double TotalCheeseGained => totalCheeseGained;
    public double TotalCheesePerSecond => totalCheesePerSecond;

    private void Awake()
    {
        EventManager.OnGameLoaded += LoadStatistics;
        EventManager.OnRatMerge += CheckHighestTier;
        EventManager.OnRatMerge += AddToTotalMerges;
        EventManager.OnRatMerge += CalculateTotalCheesePerSecondOnMerge;
        EventManager.OnCheeseGenerated += AddCheeseToTotal;
        EventManager.OnRatSpawn += CalculateTotalCheesePerSecond;
    }

    private void OnDisable()
    {
        EventManager.OnGameLoaded -= LoadStatistics;
        EventManager.OnRatMerge -= CheckHighestTier;
        EventManager.OnRatMerge -= AddToTotalMerges;
        EventManager.OnRatMerge -= CalculateTotalCheesePerSecondOnMerge;
        EventManager.OnCheeseGenerated -= AddCheeseToTotal;
        EventManager.OnRatSpawn -= CalculateTotalCheesePerSecond;
    }

    private void LoadStatistics(SaveGameManager saveGameManager)
    {
        highestTierReached = saveGameManager.highestTierReached;
        totalMerges = saveGameManager.totalMerges;
        totalCheeseGained = saveGameManager.totalCheeseGained;
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

    private void AddCheeseToTotal(double amount)
    {
        totalCheeseGained += amount;
    }

    private void CalculateTotalCheesePerSecond()
    {
        //reset value
        totalCheesePerSecond = 0;
        foreach (var rat in ratManager.SpawnedRats)
        {
            totalCheesePerSecond += rat.CheesePerSecond;
        }
    }
    //method to subscribe to the OnRatMerge event.
    private void CalculateTotalCheesePerSecondOnMerge(int tier)
    {
        CalculateTotalCheesePerSecond();
    }
}