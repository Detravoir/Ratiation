using System;
using Scriptable_Objects;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rat : MonoBehaviour
{
    [SerializeField] public RatType type;
    public int tier = 1;
    public double CheesePerSecond { get; private set;}
    
    private DragRats _dragRatsScript;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private bool _hasDestination;
    private float _moveTimer;
    private float _walkTime;
    private float _cheeseTimer = 10f;

    private Vector3 _destination, _offset;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _dragRatsScript = DragRats.Instance;
        SetRat();
    }

    void Start()
    {
        _moveTimer = Random.Range(1f, 6f);
    }

    void Update()
    {
        UpdateDestination();
        GenerateCheese();
    }

    private void UpdateDestination()
    {
        _moveTimer -= Time.deltaTime;
        
        //Check if the rat is not being dragged
        if (_dragRatsScript.IsDragged) return;
        
        //Check if the rat has a destination
        if (_hasDestination)
        {
            //Check if the destination is far away enough
            if (Vector3.Distance(transform.position, _destination) > .5f)
            {                   
                //Move to the destination
                transform.position = Vector3.MoveTowards(transform.position, _destination, Random.Range(1f, 3f) * Time.deltaTime);                   
            }
            else
            {
                _hasDestination = false;
            }
        }
        else
        {
            if (!(_moveTimer <= 0)) return;
            //Get new random destination.
            var bounds = RatManager.Instance.wall.bounds;
            _destination = new Vector2(Random.Range(bounds.extents.x, (bounds.extents.x * -1)), Random.Range(bounds.extents.y, (bounds.extents.y * -1)));
            _hasDestination = true;
            _moveTimer = Random.Range(1f, 6f);
        }
    }

    private void CalculateCheesePerSecond()
    {
        CheesePerSecond = (Math.Pow(type.BaseCheesePerSecond, tier) + 0.5 * tier);
    }
    private void GenerateCheese()
    {
        _cheeseTimer -= Time.deltaTime;

        if (!(_cheeseTimer <= 0)) return;
        
        //calculate amount of cheese generated.
        var cheeseGenerated = CheesePerSecond * 10;
        //Fire On cheese event
        EventManager.OnCheeseGenerated?.Invoke(cheeseGenerated);
        _cheeseTimer = 10f;
    }
    
    public void SetRat()
    {
        _spriteRenderer.sprite = type.RatSpritesAtlas.GetSprite(tier.ToString());
        _boxCollider.size = _spriteRenderer.sprite.bounds.size;
        CalculateCheesePerSecond();
    }
    
    public void Evolve()
    {
        //check if tier up isn't greater than maxTiers.
        //TODO: This doesn't cancel the destruction of the other rat.
        if (tier + 1 > type.MaxTiers) return;
        tier++;
        SetRat();
        CalculateCheesePerSecond();
    }
}