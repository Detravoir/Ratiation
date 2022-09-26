using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class UnlockAtTier : MonoBehaviour
    {
        [SerializeField] private GameObject objectToUnlock;
        [SerializeField] private int tierToUnlockAt;
        private bool _subscribed;

        private void Awake()
        {
            EventManager.OnRatMerge += CheckTier;
            _subscribed = true;
        }

        private void OnDisable()
        {
            if (!_subscribed) return;
            EventManager.OnRatMerge -= CheckTier;
            _subscribed = false;
        }

        private void CheckTier(int tier)
        {
            if (tier < tierToUnlockAt) return;
            
            objectToUnlock.SetActive(true);
            EventManager.OnRatMerge -= CheckTier;
            _subscribed = false;
        }
    }
}