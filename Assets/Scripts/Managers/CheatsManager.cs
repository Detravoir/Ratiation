using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatsManager : MonoBehaviour
{

    public Button confirmButton;

    public TMP_InputField cheatsInputField;
    string cheatsInput;

    void Start()
    {
        Button btn = confirmButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckCheats);
    }

    void CheckCheats()
    {
        cheatsInput = cheatsInputField.text;

        if(cheatsInput == "motherload")
        {
            EventManager.GiveMoney += AddMoney;
            Debug.Log("I AM RICH");
        }

        if(cheatsInput == "gottacatchthemall")
        {
            EventManager.UnlockRatDex += UnlockRatDex;
            Debug.Log("I caught them all!");
        }

        if( cheatsInput == "salesman")
        {
            EventManager.UnlockShop += UnlockShop;
            Debug.Log("Now i can buy every rat!");
        }

        if(cheatsInput == "VERMINTIDE")
        {
            EventManager.VERMINTIDE += VERMINTIDE;
            Debug.Log("VERMINTIDE");
        }
    }

    private void AddMoney()
    {
        // add shit ton of money
    }

    private void UnlockRatDex()
    {
        // Fully unlock the rat dex
    }

    private void UnlockShop()
    {
        // Make every rat availbable in the shop
    }

    private void VERMINTIDE()
    {
        // VERMINTIDE
    }
}
