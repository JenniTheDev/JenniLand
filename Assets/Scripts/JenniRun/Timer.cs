using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    public event Action<TimeSpan> OnTimerStopped;

    public event Action<TimeSpan> OnTimerUpdated;

    public TimeSpan TimeElapsed => DateTime.Now.Subtract(startTime);

    private DateTime startTime;
    private DateTime endTime;
    private bool isRunning;

    private void OnEnable()
    {
        OnTimerUpdated += UpdateElapsedTimeDisplay;
    }

    private void OnDisable()
    {
        OnTimerUpdated -= UpdateElapsedTimeDisplay;
    }

    private void Update()
    {
        if (isRunning)
        {
            OnTimerUpdated?.Invoke(TimeElapsed);
        }
    }

    public void ResetTimer()
    {
        isRunning = true;
        startTime = DateTime.Now;
    }

    public void StopTimer()
    {
        isRunning = false;
        endTime = DateTime.Now;
        OnTimerStopped?.Invoke(TimeElapsed);
    }

    public void UpdateElapsedTimeDisplay(TimeSpan elapsedTime)
    {
        timerText.text = $"{TimeElapsed.ToString("ss''ff")}";
    }
}