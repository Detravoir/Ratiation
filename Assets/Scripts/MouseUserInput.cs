using UnityEngine;

public class MouseUserInput : UserInput
{
    public override bool Down()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override bool Up()
    {
        return Input.GetMouseButtonUp(0);
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