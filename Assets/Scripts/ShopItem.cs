using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptable_Objects;
using Unity.VisualScripting;
using TMPro;

public class ShopItem : MonoBehaviour
{
    
    [SerializeField] private CanBeBought thingToBuy;   //scriptable object for content fill.
    [SerializeField] private TMP_Text buyButtonText;
    private double _cost;                              //used to hold the cost of the next level.

    private void Awake()
    {
        CalculateCost();
    }
    
    //Buy gets called when the UI button gets clicked.
    [ContextMenu("Buy")]
    public void Buy()
    {
        //Check if not going over the buy limit.
        if (thingToBuy.BuyLimit != 0)
        {
            if (thingToBuy.TimesBought + 1 > thingToBuy.BuyLimit) return;
        }
        //Check if cost is not higher then current amount of RatPower.
        if (_cost > CurrencyManager.TotalRatPower) return;
        //Check if buying was a succes.
        if (!thingToBuy.HasBeenBought()) return;
        //eventually deduct the cheese.
        CurrencyManager.DeductRatPower(_cost);
        CalculateCost();
    }

    //Calculates the cost of the next level.
    [ContextMenu("Calculate Cost")]
    private void CalculateCost()
    {
        _cost = Math.Round(thingToBuy.BaseCost * Math.Pow(thingToBuy.IncrementCostFactor, thingToBuy.TimesBought + 1));
        
        //check if buy limit has been reached.
        if (thingToBuy.BuyLimit != 0)
        {
            if (thingToBuy.TimesBought >= thingToBuy.BuyLimit)
            {
                buyButtonText.text = "Max Level";
                return;
            }
        }

        buyButtonText.text = _cost.ToString();
    }
}
