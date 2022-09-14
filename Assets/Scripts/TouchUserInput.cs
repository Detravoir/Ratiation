using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUserInput : UserInput
{
    public override bool Down()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                return true;
            }
        }

        return false;
    }

    public override bool Up()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                return true;
            }
        }

        return false;
    }

    public override bool Pressed()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                return true;
            }
        }

        return false;
    }

    public override RaycastHit2D GetHit()
    {
        return Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.GetTouch(0).position));
    }

    public override Vector3 GetPosition()
    {
        return _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
    }
}