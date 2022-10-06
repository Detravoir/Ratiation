using System;

public static class EventManager
{
    public static Action<SaveGameManager> OnGameLoaded;
    
    public static Action<int> OnRatMerge;

    public static Action<double> OnCheeseGenerated;

    public static Action OnRatSpawn;

    //Cheat events
    public static Action GiveMoney;
    public static Action UnlockRatDex;
    public static Action UnlockShop;
    public static Action VERMINTIDE;
}