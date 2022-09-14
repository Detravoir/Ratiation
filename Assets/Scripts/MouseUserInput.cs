
using System.Collections.Generic;
using UnityEngine;

public class MouseUserInput : UserInput
{
    public override bool Down()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }

    public override bool Up()
    {
        if (Input.GetMouseButtonUp(0))
        {
            return true;
        }
        return false;
    }

    public override bool Pressed()
    {
        return Input.GetMouseButton(0);
    }

    public override RaycastHit2D GetHit()
    {
        return Physics2D.GetRayIntersection(_camera.ScreenPointToRay(Input.mousePosition));
    }

    public override Vector3 GetPosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
