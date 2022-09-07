using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    //event for Rats to subscribe to.
    public static Func<decimal> TaxRatsEvent;

    private decimal _totalRatPower = 0;

    private void Awake()
    {
        StartCoroutine(TaxRats());
    }

    private IEnumerator TaxRats()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            
            //TODO: Add up the return of TaxRatsEvent.
            TaxRatsEvent?.Invoke();
        }
    }
    
    //TODO: Deduct RatPower method.
    //TODO: Add RatPower method
}
