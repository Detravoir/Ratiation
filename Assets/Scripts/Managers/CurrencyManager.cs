using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    //event for Rats to subscribe to.
    public static Action TaxRatsEvent;
    
    private static Coroutine _taxRatCoroutine;
    public static double _totalRatPower = 0;
    public static double TotalRatPower
    {
        get => _totalRatPower;
    }

    private void Awake()
    {
        _taxRatCoroutine = StartCoroutine(TaxRats());
        SaveGameManager.InformationLoaded += LoadRatPower;
    }

    private void LoadRatPower()
    {
        _totalRatPower = SaveGameManager.totalratpower;
    }

    private void OnDisable()
    {
        StopCoroutine(_taxRatCoroutine);
        SaveGameManager.InformationLoaded -= LoadRatPower;
    }

    private static IEnumerator TaxRats()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            TaxRatsEvent?.Invoke();
        }
    }
    
    public static void DeductRatPower(double amount)
    {
        _totalRatPower -= amount;
    }
    
    public static void AddRatPower(double amount)
    {
        _totalRatPower += amount;
    }
}
