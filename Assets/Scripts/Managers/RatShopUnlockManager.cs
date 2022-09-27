using System;
using UnityEngine;

namespace UI
{
    public class RatShopUnlockManager : UnlockManager
    {
        protected override void Unlock(int tier)
        {
            for (var i = 0; i < tier; i++)
            {
                items[i].SetActive(true);
            }
        }
    }
}