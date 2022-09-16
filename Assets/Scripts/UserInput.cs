using System;
using UnityEngine;

public abstract class UserInput : MonoBehaviour
{
    protected Camera _camera;

    protected void Awake()
    {
        _camera = Camera.main;
    }

    public abstract bool Down();
    public abstract bool Up();
    public abstract bool Pressed();

    public abstract RaycastHit2D GetHit();
    public abstract Vector3 GetPosition();
    
}
