using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public abstract class UnlockManager : MonoBehaviour
    {
        [FormerlySerializedAs("items")] [SerializeField] protected GameObject[] itemsToUnlock;
        
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