using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;

public class RatManager : MonoBehaviour
{

    public static RatManager Instance;
    public SpriteRenderer wall;
    
    [FormerlySerializedAs("ratSpawnTime")] [SerializeField] private float ratSpawnInterval = 10f;
    [SerializeField] private GameObject ratPrefab;
    [SerializeField] private List<RatType> ratTypes;
    [SerializeField] private UpgradeType spawnRateUpgrade;
    [SerializeField] private UpgradeType spawnChanceUpgrade;
    [SerializeField] private UpgradeType spawnHigherTierChanceUpgrade;
    [SerializeField] private int maxRats = 16;

    public List<Rat> SpawnedRats { get; private set; }
    public int MaxRats => maxRats;
    public List<RatType> RatTypes => ratTypes;

    private Coroutine _spawnRatCoroutine;

    public RatManager(List<Rat> spawnedRats)
    {
        SpawnedRats = spawnedRats;
    }

    void Awake()
    {
        Instance = this;
        _spawnRatCoroutine = StartCoroutine(SpawnRatTimer());
        SpawnedRats = new List<Rat>();
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
            if (SpawnedRats.Count < maxRats)
            {
                var type = Random.Range(0f, 100f) > 100 - 5 * spawnChanceUpgrade.Level ? ratTypes[1] : ratTypes[0];
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
        
        SpawnedRats.Add(newRat);
        EventManager.OnRatSpawn?.Invoke();
    }

    public void RemoveRat(Rat rat)
    {
        SpawnedRats.Remove(rat);
        Destroy(rat.gameObject);
    }
    
    public void SpawnLoadedRat(int type, int tier)
    {
        SpawnRat(RatTypes[type], tier);
    }
}
