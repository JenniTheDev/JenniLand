using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Managers/GameStatusEventManager")]
public class JenniRunEventManager : ScriptableObject
{
    public event Action OnJenniRunGameStart;

    public event Action OnJenniRunGameStop;

    public event Action<TimeSpan> OnTimerStopped;

    public event Action<TimeSpan> OnTimerUpdated;

    public void RaiseOnJenniRunStart()
        => OnJenniRunGameStart?.Invoke();

    public void RaiseOnJenniRunStop()
        => OnJenniRunGameStop?.Invoke();

    public void RaiseStopTimer(TimeSpan timePassed)
    {
        OnTimerStopped?.Invoke(timePassed);
    }

    public void RaiseTimerUpdated(TimeSpan timePassed)
    {
        OnTimerUpdated?.Invoke(timePassed);
    }
}