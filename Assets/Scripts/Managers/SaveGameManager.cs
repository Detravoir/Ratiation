using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveGameManager : MonoBehaviour
{
    //Fields
    private RatManager _ratManager;
    public List<int> ratAmountPerTier;
    public double cheese;
    [FormerlySerializedAs("ShopItems")] [SerializeField] private List<CanBeBought> shopItems;
    
    [SerializeField] private StatisticsManager statisticsManager;
    public double totalCheeseGained;
    public int totalMerges;
    public int highestTierReached;

    private void Awake()
    {
        _ratManager = RatManager.Instance;
        Load();
    }

    void OnApplicationQuit()
    {
        Save();
    }

    private void Start()
    {
        _ratManager.LoadRats(ratAmountPerTier);
    }

    public void Update()
    {
        ProcessRatAmountPerTier();
    }

    [ContextMenu("Save Game")]
    public void Save()
    {
        ProcessRatAmountPerTier();
        SaveRatAmountPerTier();
        SaveCheeseAmount();
        SaveShopItems();
        SaveStatistics();
    }

    [ContextMenu("Load Game")]
    public void Load()
    {
        LoadRatAmountPerTier();
        LoadCheeseAmount();
        LoadShopItems();
        LoadStatistics();
        
        EventManager.OnGameLoaded.Invoke(this);
    }

    //TODO: Save rat type.
    private void ProcessRatAmountPerTier()
    {
        // reset list first
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            ratAmountPerTier[i] = 0;
        }

        int totalAmountOfRats = _ratManager.spawnedRats.Count;
        if (totalAmountOfRats > 0)
        {
            for (int i = 0; i < totalAmountOfRats; i++)
            {
                int ratTier = _ratManager.spawnedRats[i].tier;
                ratAmountPerTier[ratTier]++;
            }
        }
    }

    private void SaveCheeseAmount() 
    {
        cheese = CurrencyManager.Cheese;
        PlayerPrefs.SetString("TotalRatPower", cheese.ToString(CultureInfo.CurrentCulture));
    }
    private void LoadCheeseAmount()
    {
        cheese = Convert.ToDouble(PlayerPrefs.GetString("TotalRatPower"));
    }
    
    private void SaveRatAmountPerTier()
    {
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            PlayerPrefs.SetInt("AmountOfRatsInTier" + i.ToString(), ratAmountPerTier[i]);
        }
    }
    private void LoadRatAmountPerTier()
    {
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            ratAmountPerTier[i] = PlayerPrefs.GetInt("AmountOfRatsInTier" + i.ToString());
        }
    }
    
    private void SaveShopItems()
    {
        foreach (var item in shopItems)
        {
            PlayerPrefs.SetInt(item.name, item.TimesBought);
        }
    }
    private void LoadShopItems()
    {
        foreach (var item in shopItems)
        {
            item.TimesBought = PlayerPrefs.GetInt(item.name);
        }
    }

    private void SaveStatistics()
    {
        PlayerPrefs.SetString("TotalCheeseGained", statisticsManager.TotalCheeseGained.ToString(CultureInfo.CurrentCulture));
        PlayerPrefs.SetInt("TotalMerges", statisticsManager.TotalMerges);
        PlayerPrefs.SetInt("HighestTierReached", statisticsManager.HighestTierReached);
    }
    private void LoadStatistics()
    {
        totalCheeseGained = Convert.ToDouble(PlayerPrefs.GetString("TotalCheeseGained"));
        totalMerges = PlayerPrefs.GetInt("TotalMerges");
        highestTierReached = PlayerPrefs.GetInt("HighestTierReached");
    }
}
