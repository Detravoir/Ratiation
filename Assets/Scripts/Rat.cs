using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rat : MonoBehaviour
{
    public int tier = 0;
    private SpriteRenderer spriteRenderer;
    bool hasDestination;
    public DragRats dragratsscript;

    Vector3 destination, offset;

    float timer;
    float walkTime;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dragratsscript = GetComponent<DragRats>();
        
        //Subscribe GenerateRatPower() to the TaxRatsEvent of the CurrencyManager.
        CurrencyManager.TaxRatsEvent += GenerateRatPower;
    }

    private void OnDisable()
    {
        //Unsubscribe when the object gets disabled. Otherwise a null reference error will be thrown if the event is fired.
        CurrencyManager.TaxRatsEvent -= GenerateRatPower;
    }

    void Start()
    {
        timer = Random.Range(1f, 6f);
    }

    void Update()
    {
        Debug.Log(timer);
        timer -= Time.deltaTime;
        //Check if the rat is not being dragged
        if (!dragratsscript.isDragged)
        {          
            //Check if the rat has a destination
            if (hasDestination)
            {
                //Check if the destination is far away enough
                if (Vector3.Distance(transform.position, destination) > .5f)
                {                   
                    //Move to the destination
                    transform.position = Vector3.MoveTowards(transform.position, destination, Random.Range(1f, 3f) * Time.deltaTime);                   
                }
                else
                {
                    hasDestination = false;
                }
            }
            else
            {
                if (timer <= 0)
                {
                    GetNewRandomDestination();
                    timer = Random.Range(1f, 6f);
                }                        
            }
        }
    }

    public void GetNewRandomDestination()
    {
        destination = new Vector2(Random.Range(GameManager.gameManager.wall.bounds.extents.x, (GameManager.gameManager.wall.bounds.extents.x * -1)), Random.Range(GameManager.gameManager.wall.bounds.extents.y, (GameManager.gameManager.wall.bounds.extents.y * -1)));
        hasDestination = true;
    }

    public void Set_Rat()
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.rat_Sprites[tier];
    }

    public void Evolve()
    {
        tier++;
        Set_Rat();
        //spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    //method used for calculating how much RatPower is being generated.
    private void GenerateRatPower(){
        //Add rat power to the pool of total rat power.
        CurrencyManager.AddRatPower(10);
    }
}