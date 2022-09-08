using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public SpriteRenderer wall;
    
    public GameObject rat_Prefab;

    public string[] rat_Names;
    public Sprite[] rat_Sprites, poop_Sprites;

    public float Timer = 10;

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
            Timer = 10f;
        }     
    }

    public void Spawn_Rat()
    {
        //Pick a location to spawn the rat
        Vector2 position = new Vector2(Random.Range(wall.bounds.extents.x, (wall.bounds.extents.x * -1)), Random.Range(wall.bounds.extents.y, (wall.bounds.extents.y * -1)));
             
        //Spawn a rat
        Instantiate(rat_Prefab, position, Quaternion.identity, null);            
    }
}
