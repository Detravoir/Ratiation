namespace UI
{
    public class IndexUnlockManager : UnlockManager
    {
        protected override void Unlock(int tier)
        {
            for (var i = 0; i < tier; i++)
            {
                itemsToUnlock[i].SetActive(true);
            }
        }
    }
}