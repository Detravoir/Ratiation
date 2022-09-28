using System;


public static class EventManager
{
    public static Action<SaveGameManager> OnGameLoaded;
    
    public static Action<int> OnRatMerge;

    public static Action<double> OnCheeseGenerated;

}