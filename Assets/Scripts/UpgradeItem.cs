using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptable_Objects;
using Unity.VisualScripting;

public class UpgradeItem : MonoBehaviour
{
    //scriptable object for content fill.
    [SerializeField] private UpgradeType upgradeType;
    
    //Event for all dependent objects of the upgrade to subscribe to.
    public event Action UpgradeEvent;
    
    //Buy gets called when the UI button gets clicked.
    public void Buy()
    {
        UpgradeEvent?.Invoke();
    }
}
