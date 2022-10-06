using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatsManager : MonoBehaviour
{

    public TMP_InputField cheatsInputField;
    string cheatsInput;

    void Start()
    {
    }

    public void CheckCheats()
    {
        cheatsInput = cheatsInputField.text;

        if(cheatsInput == "motherload")
        {
            EventManager.OnCheeseGenerated?.Invoke(1000000000);
            Debug.Log("I AM RICH");
        }

        if(cheatsInput == "gottacatchthemall")
        {
            EventManager.OnRatMerge?.Invoke(30);
            Debug.Log("I caught them all!");
        }

        if(cheatsInput == "VERMINTIDE")
        {
            EventManager.VERMINTIDE?.Invoke();
            Debug.Log("VERMINTIDE");
        }
    }
}
