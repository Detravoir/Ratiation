using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static double Cheese { get; private set; } = 0;

    private void Awake()
    {
        EventManager.OnGameLoaded += LoadCheese;
        EventManager.OnCheeseGenerated += AddRatPower;
    }

    private void OnDisable()
    {
        EventManager.OnGameLoaded -= LoadCheese;
        EventManager.OnCheeseGenerated -= AddRatPower;
    }

    private void LoadCheese(SaveGameManager saveGameManager)
    {
        Cheese = saveGameManager.cheese;
    }
    
    public static void DeductRatPower(double amount)
    {
        Cheese -= amount;
    }
    
    public static void AddRatPower(double amount)
    {
        Cheese += amount;
    }
}