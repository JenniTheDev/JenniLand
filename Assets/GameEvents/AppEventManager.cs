// Jenni
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Appwide Event Manager")]
public class AppEventManager : ScriptableObject {

    #region Events and Delegates

    public delegate void OnAppStartHandler();

    public event OnAppStartHandler OnAppStart;

    public delegate void OnAppExitHandler();

    public event OnAppExitHandler OnAppExit;

    #endregion Events and Delegates

    #region Class Methods

    private void Awake() {
    }

    private void OnEnable() {
    }

    private void OnDisable() {
    }

    private void OnDestroy() {
    }

    public void BroadcastAppStart() {
        OnAppStart?.Invoke();
    }

    public void BroadcastAppExit() {
        OnAppExit?.Invoke();
    }

    #endregion Class Methods
}