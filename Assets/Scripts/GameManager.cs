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

    public int coins;

    void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        Spawn_Rat();
    }

    void Update()
    {
        
    }

    public void Spawn_Rat()
    {
        Vector3 position = new Vector3(Random.Range(wall.bounds.extents.x - 15, (wall.bounds.extents.x * -1) + 15), Random.Range(wall.bounds.extents.y - 25, (wall.bounds.extents.y * -1) + 25), 0);
        Instantiate(rat_Prefab, position, Quaternion.identity, null);
    }

}
