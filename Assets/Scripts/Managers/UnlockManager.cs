using UnityEngine;

namespace UI
{
    public abstract class UnlockManager : MonoBehaviour
    {
        [SerializeField] protected GameObject[] items;
        
        private void Awake()
        {
            EventManager.OnGameLoaded += LoadUnlockedItems;
            EventManager.OnRatMerge += Unlock;
        }
        
        private void OnDisable()
        {
            EventManager.OnGameLoaded -= LoadUnlockedItems;
            EventManager.OnRatMerge -= Unlock;
        }

        private void LoadUnlockedItems(SaveGameManager saveGameManager)
        {
            Unlock(saveGameManager.highestTierReached);
        }

        protected abstract void Unlock(int tier);
    }
}