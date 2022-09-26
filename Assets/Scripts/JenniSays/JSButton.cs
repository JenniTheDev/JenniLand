// Jenni
using SOEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSButton : MonoBehaviour
{
    [SerializeField] private GameEventJSButton onButtonClick;
    [SerializeField] private Animation buttonAnimation;
    [SerializeField] private AudioClip buttonAudioClip;

    public Animation ButtonAnimation { get => buttonAnimation; }
    public AudioClip ButtonAudioClip { get => buttonAudioClip; }

    public void ActivateButton() {
        onButtonClick.Raise(this);
    }
}
