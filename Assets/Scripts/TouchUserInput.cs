using UnityEngine;

public class TouchUserInput : UserInput
{
    public override bool Down()
    {
        if (Input.touchCount <= 0) return false;
        var touch = Input.GetTouch(0);
        return touch.phase == TouchPhase.Began;
    }

    public override bool Up()
    {
        if (Input.touchCount <= 0) return false;
        var touch = Input.GetTouch(0);
        return touch.phase == TouchPhase.Ended;
    }

    public override bool Pressed()
    {
        if (Input.touchCount <= 0) return false;
        var touch = Input.GetTouch(0);
        return touch.phase is TouchPhase.Stationary or TouchPhase.Moved;
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