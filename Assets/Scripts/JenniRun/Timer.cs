using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private JenniRunEventManager gameEventManager;

    public TimeSpan TimeElapsed => DateTime.Now.Subtract(startTime);

    private DateTime startTime;
    private DateTime endTime;
    private bool isRunning;

    private void OnEnable()
    {
        gameEventManager.OnTimerUpdated += UpdateElapsedTimeDisplay;
        gameEventManager.OnJenniRunGameStart += ResetTimer;
        gameEventManager.OnJenniRunGameStop += StopTimer;
    }

    private void OnDisable()
    {
        gameEventManager.OnTimerUpdated -= UpdateElapsedTimeDisplay;
        gameEventManager.OnJenniRunGameStart -= ResetTimer;
        gameEventManager.OnJenniRunGameStop -= StopTimer;
    }

    private void Update()
    {
        if (isRunning)
        {
            gameEventManager.RaiseTimerUpdated(TimeElapsed);
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
        gameEventManager.RaiseStopTimer(TimeElapsed);
    }

    public void UpdateElapsedTimeDisplay(TimeSpan elapsedTime)
    {
        timerText.text = $"{TimeElapsed.ToString("ss''ff")}";
    }
}