using System;
using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rat : MonoBehaviour
{
    private DragRats _dragRatsScript;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private bool _hasDestination;
    [SerializeField] public RatType type;
    public int tier = 1;
    
    Vector3 destination, offset;

    float timer;
    float walkTime;

    private void Awake()
    {
        CurrencyManager.TaxRatsEvent += GenerateRatPower; //Subscribe GenerateRatPower() to the TaxRatsEvent of the CurrencyManager.
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _dragRatsScript = DragRats.Instance;
        Set_Rat();
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
        timer -= Time.deltaTime;
        //Check if the rat is not being dragged
        if (!_dragRatsScript.IsDragged)
        {          
            //Check if the rat has a destination
            if (_hasDestination)
            {
                //Check if the destination is far away enough
                if (Vector3.Distance(transform.position, destination) > .5f)
                {                   
                    //Move to the destination
                    transform.position = Vector3.MoveTowards(transform.position, destination, Random.Range(1f, 3f) * Time.deltaTime);                   
                }
                else
                {
                    _hasDestination = false;
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
        _hasDestination = true;
    }

    public void Set_Rat()
    {
        _spriteRenderer.sprite = type.RatSpritesAtlas.GetSprite(tier.ToString());
        _boxCollider.size = _spriteRenderer.sprite.bounds.size;
    }

    public void Evolve()
    {
        //check if tier up isn't greater than maxTiers.
        //TODO: This doesn't cancel the destruction of the other rat.
        if (tier + 1 > type.MaxTiers) return;
        tier++;
        Set_Rat();
    }

    //method used for calculating how much RatPower is being generated.
    private void GenerateRatPower(){
        //Add rat power to the pool of total rat power.
        var powerGenerated = type.BasePowerPerMinute * tier / 6;
        CurrencyManager.AddRatPower(powerGenerated);
    }
}