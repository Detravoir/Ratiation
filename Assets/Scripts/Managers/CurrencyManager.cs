using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private static double _totalRatPower = 0;
    public static double TotalRatPower
    {
        get => _totalRatPower;
    }

    private void Awake()
    {
        SaveGameManager.InformationLoaded += LoadRatPower;
        EventManager.OnCheeseGenerated += AddRatPower;
    }

    private void LoadRatPower()
    {
        _totalRatPower = SaveGameManager.totalratpower;
    }

    private void OnDisable()
    {
        SaveGameManager.InformationLoaded -= LoadRatPower;
        EventManager.OnCheeseGenerated -= AddRatPower;
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
