using TMPro;
using UnityEngine;

namespace UI
{
    public class ShowCheesePerSecond : MonoBehaviour
    {
        private TMP_Text _tmpText;

        private void Awake()
        {
            _tmpText = gameObject.GetComponent<TMP_Text>() as TMP_Text;
        }

        private void Update()
        {
            UpdateCheesePerSecond();
        }

        //get TotalCheesePerSecond from the StatisticsManager
        private void UpdateCheesePerSecond()
        {
            _tmpText.text =$"{FormatNumber.FormatDouble(StatisticsManager.TotalCheesePerSecond)} p/s";
        }
    }
}