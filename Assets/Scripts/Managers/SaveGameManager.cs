using System;
using System.Collections.Generic;
using System.Globalization;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveGameManager : MonoBehaviour
{
    //Fields
    private RatManager _ratManager;
    public double cheese;
    [FormerlySerializedAs("ShopItems")] [SerializeField] private List<CanBeBought> shopItems;
    
    public double totalCheeseGained = 0;
    public int totalMerges = 0;
    public int highestTierReached = 0;

    private void Awake()
    {
        _ratManager = RatManager.Instance;
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    [ContextMenu("Save Game")]
    public void Save()
    {
        SaveRats();
        SaveCheeseAmount();
        SaveShopItems();
        SaveStatistics();
        PlayerPrefs.Save();
    }

    [ContextMenu("Load Game")]
    public void Load()
    {
        LoadRats();
        LoadCheeseAmount();
        LoadShopItems();
        LoadStatistics();
        EventManager.OnGameLoaded.Invoke(this);
    }

    private void SaveCheeseAmount() 
    {
        cheese = CurrencyManager.Cheese;
        PlayerPrefs.SetString("Cheese", cheese.ToString(CultureInfo.CurrentCulture));
    }
    private void LoadCheeseAmount()
    {
        cheese = Convert.ToDouble(PlayerPrefs.GetString("Cheese", "0"));
    }
    
    private void SaveRats()
    {
        var spawnedRats = _ratManager.SpawnedRats;
        var ratCount = spawnedRats.Count;
        
        PlayerPrefs.SetInt("RatCount", ratCount);
        for (var i = 0; i < ratCount; i++)
        {
            PlayerPrefs.SetInt($"rat{i}Type", _ratManager.RatTypes.IndexOf(spawnedRats[i].type));
            PlayerPrefs.SetInt($"rat{i}Tier", _ratManager.SpawnedRats[i].tier);
        }
    }
    private void LoadRats()
    {
        var ratCount = PlayerPrefs.GetInt("RatCount");
        for (var i = 0; i < ratCount; i++)
        {
            var type = PlayerPrefs.GetInt($"rat{i}Type");
            var tier = PlayerPrefs.GetInt($"rat{i}Tier");
            _ratManager.SpawnLoadedRat(type, tier);
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
        PlayerPrefs.SetString("TotalCheeseGained", StatisticsManager.TotalCheeseGained.ToString(CultureInfo.CurrentCulture));
        PlayerPrefs.SetInt("TotalMerges", StatisticsManager.TotalMerges);
        PlayerPrefs.SetInt("HighestTierReached", StatisticsManager.HighestTierReached);
    }
    private void LoadStatistics()
    {
        totalCheeseGained = Convert.ToDouble(PlayerPrefs.GetString("TotalCheeseGained", "0"));
        totalMerges = PlayerPrefs.GetInt("TotalMerges");
        highestTierReached = PlayerPrefs.GetInt("HighestTierReached");
    }
}