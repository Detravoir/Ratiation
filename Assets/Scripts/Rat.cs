using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rat : MonoBehaviour
{

    public int tier;
    bool isDragged, hasDestination;

    Vector3 destination, offset;

    [SerializeField] private float range;

    private void Awake()
    {
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
        Set_Rat();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the rat is not being dragged
        if (!isDragged)
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
                destination = new Vector2(Random.Range(GameManager.gameManager.wall.bounds.extents.x, (GameManager.gameManager.wall.bounds.extents.x * -1)), Random.Range(GameManager.gameManager.wall.bounds.extents.y, (GameManager.gameManager.wall.bounds.extents.y * -1)));
                hasDestination = true;
            }
        }
    }

    public void Set_Rat()
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.rat_Sprites[tier];
    }

    public void Evolve()
    {
        tier++;
        Set_Rat();
    }

    //method used for calculating how much RatPower is being genated.
    private decimal GenerateRatPower()
    {
        Debug.Log("Generating Rat Power");
        return 10;
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void OnMouseDrag()
    {
        isDragged = true;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;
    }

    private void OnMouseUp()
    {
        isDragged = false;
        Debug.Log(Physics2D.OverlapCircle(transform.position, range));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the rat is being dragged
        if (isDragged)
        {
            //Check if the dragged rat collides with the tag "Rat"
            if (collision.tag == "Rat")
            {
                //Check if the collision between rats both have the same tier
                if (collision.GetComponent<Rat>().tier == tier)
                {
                    Evolve();

                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Check if the rat is being dragged
        if (isDragged)
        {
            //Check if the dragged rat collides with the tag "Rat"
            if (collision.tag == "Rat")
            {
                //Check if the collision between rats both have the same tier
                if (collision.GetComponent<Rat>().tier == tier)
                {
                    Evolve();
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}