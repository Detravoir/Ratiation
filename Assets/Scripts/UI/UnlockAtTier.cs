using UnityEngine;

namespace UI
{
    public class UnlockAtTier : MonoBehaviour
    {
        [SerializeField] private GameObject objectToUnlock;
        [SerializeField] private int tierToUnlockAt;

        private void Awake()
        {
            EventManager.OnGameLoaded += LoadIfUnlocked;
            EventManager.OnRatMerge += CheckTier;
        }

        private void OnDisable()
        {
            EventManager.OnGameLoaded += LoadIfUnlocked;
            EventManager.OnRatMerge -= CheckTier;
        }

        private void LoadIfUnlocked(SaveGameManager saveGameManager)
        {
            CheckTier(saveGameManager.highestTierReached);
        }

        private void CheckTier(int tier)
        {
            if (tier < tierToUnlockAt) return;
            objectToUnlock.SetActive(true);
        }
    }
}