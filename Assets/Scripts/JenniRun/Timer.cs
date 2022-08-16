using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private TMP_Text timerText;

    private float minutes;
    private float seconds;
    private float miliseconds;

    public void Start()
    {
    }

    public void Update()
    {
        timer += Time.deltaTime;
        // timerText.text = timer.ToString();
        DisplayTime();
    }

    private void DisplayTime()
    {
        // minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        miliseconds = (timer % 1) * 10000000;
        timerText.text = string.Format($"{seconds}:{miliseconds}");
    }
}