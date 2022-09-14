using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameManager gamemanager;
    public List<int> ratAmountPerTier;

    
    private void Awake()
    {
        //Load();
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

        int totalAmountOfRats = ratSpawner.spawnedRats.Count;
        for (int i = 0; i < totalAmountOfRats; i++)
        {
            int ratTier = ratSpawner.spawnedRats[i].ratTier;
            ratAmountPerTier[ratTier]++;
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
}
