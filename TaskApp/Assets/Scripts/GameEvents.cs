using System;

public static class GameEvents
{
    public static event Action OnEndGameEvent;

    public static void InvokeEndGameEvent()
    {
        OnEndGameEvent?.Invoke();
    }
}

