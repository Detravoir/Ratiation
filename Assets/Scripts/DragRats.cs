using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DragRats : MonoBehaviour
{
    public static DragRats Instance { get; private set; }
    public Camera cam;
    [SerializeField] private UserInput userInput;

    public Rat currentlyDraggingRat;
    public float ratCheckRadius = 0.5f;
    public bool isDragged = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        InputDown();
        InputDrag();
        InputUp();
    }

    private void CompareRats(Rat thisRat, Rat otherRat)
    {
        if (thisRat.tier == otherRat.tier)
        {
            thisRat.Evolve();
            Destroy(otherRat.gameObject);
        }
    }

    private void InputDown()
    {
        if (userInput.Down()) // potentieel issues met touch
        {
            RaycastHit2D hit = userInput.GetHit();
            if (hit.collider != null)
            {
                Rat hitRat = hit.collider.GetComponent<Rat>();
                if (hitRat != null)
                {
                    currentlyDraggingRat = hitRat;
                }
            }
            else
            {
                currentlyDraggingRat = null;
            }
        }
    }

    private void InputDrag()
    {
        if (userInput.Pressed() && currentlyDraggingRat != null) // potentieel issues met touch
        {
            isDragged = true;
            Vector3 newRatDragPosition = userInput.GetPosition();
            newRatDragPosition.z = 0;
            currentlyDraggingRat.transform.position = newRatDragPosition;
        }
        else
        {
            isDragged = false;
        }
    }

    private void InputUp()
    {
        if (userInput.Up() && currentlyDraggingRat != null) // potentieel issues met touch
        {
            List<Collider2D> allColliders = new List<Collider2D>();
            allColliders.AddRange(Physics2D.OverlapCircleAll(currentlyDraggingRat.transform.position, ratCheckRadius));
            allColliders.Remove(currentlyDraggingRat.GetComponent<Collider2D>());
            if (allColliders.Count > 0)
            {
                Rat otherRat = allColliders[0].GetComponent<Rat>();
                CompareRats(currentlyDraggingRat, otherRat);
            }
            currentlyDraggingRat = null;
        }
    }
}
