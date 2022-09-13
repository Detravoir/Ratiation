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

    public float Timer = 0;

    void Awake()
    {
        gameManager = this;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        //If the timer hits 0 run Spawn_Rat function
        if (Timer <= 0f)
        {
            Spawn_Rat();
            Timer = 10f - spawnRateUpgrade.Level; //decrease by a second per level.
        }
    }

    public void Spawn_Rat()
    {
        //Pick a location to spawn the rat
        Vector2 position = new Vector2(Random.Range(wall.bounds.extents.x, (wall.bounds.extents.x * -1)), Random.Range(wall.bounds.extents.y, (wall.bounds.extents.y * -1)));
        
        //Spawn a rat
        Rat rat = Instantiate(ratPrefab, position, Quaternion.identity, null).GetComponent<Rat>();
        
        //See if its a shiney.
        if (Random.Range(0f, 100f) > 100 - 10 * spawnChanceUpgrade.Level)
        {
            rat.type= ratTypes[1];
            rat.Set_Rat();
        }
    }
}
