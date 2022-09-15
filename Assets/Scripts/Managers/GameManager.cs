using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public SpriteRenderer wall;
    
    [SerializeField] private GameObject ratPrefab;
    [SerializeField] private RatType[] ratTypes;
    [SerializeField] private UpgradeType spawnRateUpgrade;
    [SerializeField] private UpgradeType spawnChanceUpgrade;

    public List<Rat> spawnedRats;
    public int maxRats = 16;
          
    public float ratSpawnTime = 10f;
    private float ratSpawnTimer = 0f;

    public int currentRatTier = 1;

    void Awake()
    {
        gameManager = this;
        ratSpawnTimer = ratSpawnTime;
    }

    public void StartSpawnRats(List<int> ratAmountPerTier)
    {
        for (int tierNumber = 0; tierNumber < ratAmountPerTier.Count; tierNumber++)
        {
            for(int j = 0; j < ratAmountPerTier[tierNumber]; j++)
            {
                Spawn_Rat(tierNumber);
            }
        }
    }

    void Update()
    {
        ratSpawnTimer -= Time.deltaTime;
        //If the timer hits 0 run Spawn_Rat function
        if (ratSpawnTimer < 0f)
        {
            if(spawnedRats.Count < maxRats)
            {
                Spawn_Rat(currentRatTier);             
            }
            ratSpawnTimer = ratSpawnTime - spawnRateUpgrade.Level; //decrease by a second per level.
        }     
    }

    public void Spawn_Rat(int tier)
    {
        //Pick a location to spawn the rat
        Vector2 position = new Vector2(Random.Range(wall.bounds.extents.x, (wall.bounds.extents.x * -1)), Random.Range(wall.bounds.extents.y, (wall.bounds.extents.y * -1)));
        
        //Spawn a rat
        Rat newRat = Instantiate(ratPrefab, position, Quaternion.identity, null).GetComponent<Rat>();
    
        newRat.tier = tier;
        newRat.Set_Rat();

        //See if its a shiney.
        if (Random.Range(0f, 100f) > 100 - 10 * spawnChanceUpgrade.Level)
       {
            newRat.type = ratTypes[1];
            newRat.Set_Rat();
       }

        spawnedRats.Add(newRat);
    }

    public void RemoveRat(Rat rat)
    {
        spawnedRats.Remove(rat);
        Destroy(rat.gameObject);
    }
}
