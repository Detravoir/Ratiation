using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    public int tier, good_Poop, bad_Poop;

    bool isDragged;
    // Start is called before the first frame update
    void Start()
    {
        Set_Rat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Rat()
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.rat_Sprites[tier];

        bad_Poop = tier / 5;
        if(tier != 0)
        {
            good_Poop = bad_Poop + 1;
        }
        else
        {
            good_Poop = bad_Poop;
        }
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseDrag()
    {
        isDragged = true;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }
}
