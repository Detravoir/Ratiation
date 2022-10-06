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

        if(cheatsInput == "CHEATCODE")
        {
            Debug.Log("cheat is gemaakt");
        }
    }
}
