using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameManager gamemanager;
    public List<int> ratAmountPerTier;
    public static double totalratpower;

    public static Action InformationLoaded;

    private void Awake()
    {
        Load();
    }

    void OnApplicationQuit()
    {
        Save();
    }

    private void Start()
    {
        gamemanager.StartSpawnRats(ratAmountPerTier);
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
    }

    [ContextMenu("Load Game")]
    public void Load()
    {
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            ratAmountPerTier[i] = PlayerPrefs.GetInt("AmountOfRatsInTier" + i.ToString());
        }

        string ratpower = PlayerPrefs.GetString("TotalRatPower");
        totalratpower = System.Convert.ToDouble(ratpower);

        InformationLoaded.Invoke();
    }

    public void ProcessRatAmountPerTier()
    {
        // reset list first
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            ratAmountPerTier[i] = 0;
        }

        int totalAmountOfRats = gamemanager.spawnedRats.Count;
        for (int i = 0; i < totalAmountOfRats; i++)
        {
            int ratTier = gamemanager.spawnedRats[i].tier;
            ratAmountPerTier[ratTier]++;
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
}
