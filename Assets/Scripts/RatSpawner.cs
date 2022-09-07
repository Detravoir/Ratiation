using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public static GameManager gameManager;
    public SpriteRenderer wall;

    public GameObject rat_Prefab;



    private void Start()
    {
        Spawn_Rat();
    }

    void Update()
    {

    }

    public void Spawn_Rat()
    {
        Vector2 position = new Vector2(Random.Range(wall.bounds.extents.x, (wall.bounds.extents.x * -1)), Random.Range(wall.bounds.extents.y, (wall.bounds.extents.y * -1)));
        Instantiate(rat_Prefab, position, Quaternion.identity, null);
        Debug.Log(position);
    }
}
