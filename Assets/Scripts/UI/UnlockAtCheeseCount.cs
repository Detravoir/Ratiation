using UnityEngine;

namespace UI
{
    public class UnlockAtCheeseCount : MonoBehaviour
    {
        [SerializeField] private GameObject objectToUnlock;
        [SerializeField] private int cheeseCountToUnlockAt;
        private bool _subscribed;

        private void Awake()
        {
            EventManager.OnCheeseGenerated += CheckCheeseCount;
            _subscribed = true;
        }

        private void OnDisable()
        {
            if (!_subscribed) return;
            EventManager.OnCheeseGenerated -= CheckCheeseCount;
            _subscribed = false;
        }

        private void CheckCheeseCount(double amountGenerated)
        {
            if (CurrencyManager.TotalRatPower < cheeseCountToUnlockAt) return;
            
            objectToUnlock.SetActive(true);
            EventManager.OnCheeseGenerated -= CheckCheeseCount;
            _subscribed = false;
        }
    }
}