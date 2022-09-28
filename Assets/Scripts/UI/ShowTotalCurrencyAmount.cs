using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UI
{
    public class ShowTotalCurrencyAmount : MonoBehaviour
    {
        private TMP_Text _tmpText;
        void Awake()
        {
            _tmpText = gameObject.GetComponent<TMP_Text>() as TMP_Text;
        }

        private void Update()
        {
            _tmpText.text = CurrencyManager.Cheese.ToString();
        }
    }
}
