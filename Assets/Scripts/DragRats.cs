using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DragRats : MonoBehaviour
{
    public static DragRats Instance { get; private set; }
    [SerializeField] private UserInput userInput;
    [SerializeField] private float ratCheckRadius = 0.5f;

    private Rat _currentlyDraggingRat;
    public bool IsDragged { get; private set; } = false;

    private RatManager _ratManager;

    private void Awake()
    {
        _ratManager = RatManager.Instance;
        Instance = this;
    }

    private void Update()
    {
        InputDown();
        InputDrag();
        InputUp();
    }
    private RatManager GetRatManager()
    {
        if (_ratManager) return _ratManager;
        
        _ratManager = RatManager.Instance;
        return _ratManager;
    }

    private void CompareRats(Rat thisRat, Rat otherRat)
    {
        if (thisRat.tier == otherRat.tier)
        {
            thisRat.Evolve();
            GetRatManager().RemoveRat(otherRat);
        }
    }

    private void InputDown()
    {
        if (userInput.Down())
        {
            RaycastHit2D hit = userInput.GetHit();
            if (hit.collider != null)
            {
                Rat hitRat = hit.collider.GetComponent<Rat>();
                if (hitRat != null)
                {
                    _currentlyDraggingRat = hitRat;
                }
            }
            else
            {
                _currentlyDraggingRat = null;
            }
        }
    }

    private void InputDrag()
    {
        if (userInput.Pressed() && _currentlyDraggingRat != null)
        {
            IsDragged = true;
            Vector3 newRatDragPosition = userInput.GetPosition();
            newRatDragPosition.z = 0;
            _currentlyDraggingRat.transform.position = newRatDragPosition;
        }
        else
        {
            IsDragged = false;
        }
    }

    private void InputUp()
    {
        if (userInput.Up() && _currentlyDraggingRat != null)
        {
            List<Collider2D> allColliders = new List<Collider2D>();
            allColliders.AddRange(Physics2D.OverlapCircleAll(_currentlyDraggingRat.transform.position, ratCheckRadius));
            allColliders.Remove(_currentlyDraggingRat.GetComponent<Collider2D>());
            if (allColliders.Count > 0)
            {
                Rat otherRat = allColliders[0].GetComponent<Rat>();
                CompareRats(_currentlyDraggingRat, otherRat);
            }
            _currentlyDraggingRat = null;
        }
    }
}
