using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptable_Objects;
using Unity.VisualScripting;

public class UpgradeShopItem : MonoBehaviour
{
    
    [SerializeField] private UpgradeType upgradeType;   //scriptable object for content fill.
    public double Cost { get; private set; }           //used to hold the cost of the next level.

    public event Action UpgradeEvent;                   //Event for all dependent objects of the upgrade.

    private void Awake()
    {
        CalculateCost();
    }

    //Buy gets called when the UI button gets clicked.
    public void Buy()
    {
        //Check if cost is not higher then current amount of RatPower.
        if (Cost > CurrencyManager.TotalRatPower) return;
        CurrencyManager.DeductRatPower(Cost);
        upgradeType.NextLevel();
        UpgradeEvent?.Invoke();
        CalculateCost();
    }

    //Calculates the cost of the next level.
    private void CalculateCost()
    {
        Cost = upgradeType.BaseCost * (upgradeType.Level + 1) * upgradeType.CostIncrement;
    }
}
