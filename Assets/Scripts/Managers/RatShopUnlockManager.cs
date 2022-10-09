namespace UI
{
    public class RatShopUnlockManager : UnlockManager
    {
        protected override void Unlock(int tier)
        {
            for (var i = 0; i < tier; i++)
            {
                if (i - 3 >= 0)
                {
                    itemsToUnlock[i-3].SetActive(true);
                }
            }
        }
    }
}