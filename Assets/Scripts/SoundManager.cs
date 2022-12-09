// Jenni
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioSource soundtrack;

    [SerializeField] private AudioClip levelMusic;
    [SerializeField] private AudioClip start;
    [SerializeField] private AudioClip onTap;

    #region MonoBehavior

    private void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }

    #endregion MonoBehavior

    #region Methods

    private void Subscribe() {
        Unsubscribe();
    }

    private void Unsubscribe() {
    }

    #endregion Methods
}