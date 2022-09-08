using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRats : MonoBehaviour
{
    public Camera cam;

    public Rat currentlyDraggingRat;
    public float ratCheckRadius = 2f;
    public bool isDragged = false;

    private void Update()
    {
        MouseDown();
        MouseDrag();
        MouseUp();
    }

    private void CompareRats(Rat thisRat, Rat otherRat)
    {
        if (thisRat.tier == otherRat.tier)
        {
            thisRat.Evolve();
            Destroy(otherRat.gameObject);
        }
    }

    private void MouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // potentieel issues met touch
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
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

    private void MouseDrag()
    {
        if (Input.GetMouseButton(0) && currentlyDraggingRat != null) // potentieel issues met touch
        {
            isDragged = true;
            Vector3 newRatDragPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            newRatDragPosition.z = 0;
            currentlyDraggingRat.transform.position = newRatDragPosition;
        }
        else
        {
            isDragged = false;
        }
    }

    private void MouseUp()
    {
        if (Input.GetMouseButtonUp(0) && currentlyDraggingRat != null) // potentieel issues met touch
        {
            List<Collider2D> allColliders = new List<Collider2D>();
            allColliders.AddRange(Physics2D.OverlapCircleAll(cam.ScreenToWorldPoint(Input.mousePosition), ratCheckRadius));
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
