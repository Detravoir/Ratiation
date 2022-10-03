using TMPro;
using UnityEngine;

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
            _tmpText.text = FormatNumber.FormatDouble(CurrencyManager.Cheese);
        }
    }
}
