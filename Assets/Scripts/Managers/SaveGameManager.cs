using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveGameManager : MonoBehaviour
{
    //Events
    public static Action InformationLoaded;

    //Fields
    private RatManager _ratManager;
    public List<int> ratAmountPerTier;
    public static double totalratpower;
    [FormerlySerializedAs("ShopItems")] [SerializeField] private List<CanBeBought> shopItems;

    private void Awake()
    {
        _ratManager = RatManager.Instance;
        Load();
    }

    void OnApplicationPause(bool pausestatus)
    {
        if (pausestatus)
        {
            Save();
        }
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
        SaveTotalRatPower();
        SaveShopItems();
    }

    [ContextMenu("Load Game")]
    public void Load()
    {
        //Load rats
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            ratAmountPerTier[i] = PlayerPrefs.GetInt("AmountOfRatsInTier" + i.ToString());
        }
        
        //Load rat power
        var ratpower = PlayerPrefs.GetString("TotalRatPower");
        totalratpower = System.Convert.ToDouble(ratpower);
        
        LoadShopItems();
        
        InformationLoaded.Invoke();
    }

    //TODO: Save rat type.
    public void ProcessRatAmountPerTier()
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

    private void SaveTotalRatPower() 
    {
        totalratpower = CurrencyManager.TotalRatPower;

        PlayerPrefs.SetString("TotalRatPower", totalratpower.ToString());
    }

    private void SaveRatAmountPerTier()
    {
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            PlayerPrefs.SetInt("AmountOfRatsInTier" + i.ToString(), ratAmountPerTier[i]);
        }
    }

    private void SaveShopItems()
    {
        foreach (var item in shopItems)
        {
            PlayerPrefs.SetInt(item.name, item.TimesBought);
        }
    }

    public void LoadShopItems()
    {
        foreach (var item in shopItems)
        {
            item.TimesBought = PlayerPrefs.GetInt(item.name);
        }
    }
}
