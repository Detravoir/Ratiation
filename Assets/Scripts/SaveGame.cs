using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameManager gamemanager;
    public CurrencyManager currencymanager;
    public List<int> ratAmountPerTier;

    
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
    }

    [ContextMenu("Load Game")]
    public void Load()
    {
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            ratAmountPerTier[i] = PlayerPrefs.GetInt("AmountOfRatsInTier" + i.ToString());
        }
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
        int ratpower = currencymanager.TotalRatPower();
    }

    private void SaveRatAmountPerTier()
    {
        for (int i = 0; i < ratAmountPerTier.Count; i++)
        {
            PlayerPrefs.SetInt("AmountOfRatsInTier" + i.ToString(), ratAmountPerTier[i]);
        }
    }
}
