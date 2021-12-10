using System;

public class EventAction
{
    public static event Action OnStartTalk;

    public static void OnTalk()
    {
        OnStartTalk();
    }
}
