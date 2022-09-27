using UnityEngine;

namespace UI
{
    public abstract class UnlockManager : MonoBehaviour
    {
        [SerializeField] protected GameObject[] items;
        
        private void Awake()
        {
            EventManager.OnRatMerge += Unlock;
        }

        private void OnDisable()
        {
            EventManager.OnRatMerge -= Unlock;
        }

        protected abstract void Unlock(int tier);
    }
}