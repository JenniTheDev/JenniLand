// Jenni
using UnityEngine;

public class STEventManager {
    #region Singleton
    private static bool isQuitting = false;
    private static STEventManager instance = null;

    public static STEventManager Instance {
        get {
            if (instance == null && !isQuitting) {
                instance = new STEventManager();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }

    private STEventManager() {
    }

    #endregion Singleton

    #region Events and Delegates
    public delegate void OnIntroHandler();
    public event OnIntroHandler OnIntro;

    public delegate void OnGameStartHandler();
    public event OnGameStartHandler OnGameStart;

    public delegate void OnGameOverHandler();
    public event OnGameOverHandler OnGameOver;


    #endregion

    #region Class Methods

    public void BroadcastGameIntro() {
        OnIntro?.Invoke();
    }

    public void BroadcastGameStart() {
        OnGameStart?.Invoke();
    }

    public void BroadcastGameOver() {
        OnGameOver?.Invoke();
    }

    #endregion
}