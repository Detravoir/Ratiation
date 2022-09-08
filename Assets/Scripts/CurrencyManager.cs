using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    //event for Rats to subscribe to.
    public static Action TaxRatsEvent;

    private static Coroutine _taxRatCoroutine;
    private static decimal _totalRatPower = 0;
    public static decimal TotalRatPower
    {
        get => _totalRatPower;
    }

    private void Awake()
    {
        _taxRatCoroutine = StartCoroutine(TaxRats());
    }

    private void OnDisable()
    {
        StopCoroutine(_taxRatCoroutine);
    }

    private static IEnumerator TaxRats()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
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
