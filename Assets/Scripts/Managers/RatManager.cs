using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RatManager : MonoBehaviour
{

    public static RatManager Instance;
    public SpriteRenderer wall;
    
    [FormerlySerializedAs("ratSpawnTime")] [SerializeField] private float ratSpawnInterval = 10f;
    [SerializeField] private GameObject ratPrefab;
    [SerializeField] private RatType[] ratTypes;
    [SerializeField] private UpgradeType spawnRateUpgrade;
    [SerializeField] private UpgradeType spawnChanceUpgrade;
    [SerializeField] private UpgradeType spawnHigherTierChanceUpgrade;

    public List<Rat> spawnedRats;
    [SerializeField] private int maxRats = 16;

    private Coroutine _spawnRatCoroutine;
    
    void Awake()
    {
        Instance = this;
        _spawnRatCoroutine = StartCoroutine(SpawnRatTimer());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnRatCoroutine);
    }
    
    private IEnumerator SpawnRatTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(ratSpawnInterval - spawnRateUpgrade.Level);
            if (spawnedRats.Count < maxRats)
            {
                var type = Random.Range(0f, 100f) > 100 - 10 * spawnChanceUpgrade.Level ? ratTypes[1] : ratTypes[0];
                var tier = Random.Range(1, spawnHigherTierChanceUpgrade.Level + 1);
                SpawnRat(type, tier);
            };
        }
    }

    public void SpawnRat(RatType type, int tier)
    {
        //Pick a location to spawn the rat
        Vector2 position = new Vector2(Random.Range(wall.bounds.extents.x, (wall.bounds.extents.x * -1)), Random.Range(wall.bounds.extents.y, (wall.bounds.extents.y * -1)));
        
        //Spawn a rat
        Rat newRat = Instantiate(ratPrefab, position, Quaternion.identity, null).GetComponent<Rat>();

        newRat.type = type;
        newRat.tier = tier;
        newRat.SetRat();
        
        spawnedRats.Add(newRat);
    }

    public void RemoveRat(Rat rat)
    {
        spawnedRats.Remove(rat);
        Destroy(rat.gameObject);
    }
    
    public void LoadRats(List<int> ratAmountPerTier)
    {
        for (int tierNumber = 0; tierNumber < ratAmountPerTier.Count; tierNumber++)
        {
            for(int j = 0; j < ratAmountPerTier[tierNumber]; j++)
            {
                SpawnRat(ratTypes[0] , tierNumber);
            }
        }
    }
}
