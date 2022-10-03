using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField] private RatManager ratManager;

    public static int HighestTierReached { get; private set; } = 1;
    public static int TotalMerges { get; private set; } = 0;
    public static double TotalCheeseGained { get; private set; } = 0;
    public static double TotalCheesePerSecond { get; private set; }

    private void Update()
    {
        CalculateTotalCheesePerSecond();
    }

    private void Awake()
    {
        EventManager.OnGameLoaded += LoadStatistics;
        EventManager.OnRatMerge += CheckHighestTier;
        EventManager.OnRatMerge += AddToTotalMerges;
        EventManager.OnCheeseGenerated += AddCheeseToTotal;
    }

    private void OnDisable()
    {
        EventManager.OnGameLoaded -= LoadStatistics;
        EventManager.OnRatMerge -= CheckHighestTier;
        EventManager.OnRatMerge -= AddToTotalMerges;
        EventManager.OnCheeseGenerated -= AddCheeseToTotal;
    }

    private void LoadStatistics(SaveGameManager saveGameManager)
    {
        HighestTierReached = saveGameManager.highestTierReached;
        TotalMerges = saveGameManager.totalMerges;
        TotalCheeseGained = saveGameManager.totalCheeseGained;
    }

    private void CheckHighestTier(int tier)
    {
        if (tier <= HighestTierReached) return;
        HighestTierReached = tier;
    }

    private void AddToTotalMerges(int tier)
    {
        TotalMerges++;
    }

    private void AddCheeseToTotal(double amount)
    {
        TotalCheeseGained += amount;
    }

    private void CalculateTotalCheesePerSecond()
    {
        //reset value
        TotalCheesePerSecond = 0;
        foreach (var rat in ratManager.SpawnedRats)
        {
            TotalCheesePerSecond += rat.CheesePerSecond;
        }
    }
}