using System.Globalization;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ShowCheesePerSecond : MonoBehaviour
    {
        [SerializeField] private StatisticsManager statisticsManager;
        private TMP_Text _tmpText;

        private void Awake()
        {
            _tmpText = gameObject.GetComponent<TMP_Text>() as TMP_Text;
            EventManager.OnRatSpawn += UpdateCheesePerSecond;
            EventManager.OnRatMerge += UpdateCheesePerSecondOnMerge;
        }
        private void OnDisable()
        {
            EventManager.OnRatSpawn -= UpdateCheesePerSecond;
            EventManager.OnRatMerge -= UpdateCheesePerSecondOnMerge;
        }
        private void UpdateCheesePerSecond()
        {
            _tmpText.text = statisticsManager.TotalCheesePerSecond.ToString(CultureInfo.CurrentCulture);
        }
        private void UpdateCheesePerSecondOnMerge(int tier)
        {
            UpdateCheesePerSecond();
        }
    }
}