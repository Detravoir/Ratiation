using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    //event for Rats to subscribe to.
    public static Func<decimal> TaxRatsEvent;
    
    private static decimal _totalRatPower = 0;

    public static decimal TotalRatPower
    {
        get => _totalRatPower;
    }

    private void Awake()
    {
        StartCoroutine(TaxRats());
    }

    private static IEnumerator TaxRats()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            
            //TODO: Add up the return of TaxRatsEvent.
            TaxRatsEvent?.Invoke();
        }
    }
    
    public static void DeductRatPower(decimal amount)
    {
        _totalRatPower -= amount;
    }
    
    public static void AddRatPower(decimal amount)
    {
        _totalRatPower += amount;
    }
}
