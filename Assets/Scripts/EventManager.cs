// Jenni
using UnityEngine;

public class EventManager : MonoBehaviour {
    #region Singleton
    private static bool isQuitting = false;
    private static EventManager instance = null;

    public static EventManager Instance {
        get {
            if (instance == null && !isQuitting) {
                FindOrCreateInstance();
                Application.quitting += () => isQuitting = true;
            }
            return instance;
        }
    }



    #endregion Singleton

    #region Events and Delegates
    public delegate void OnAppStartHandler();
    public event OnAppStartHandler OnAppStart;

    public delegate void OnAppExitHandler();
    public event OnAppExitHandler OnAppExit;

    #endregion

    #region Class Methods

    public void BroadcastAppStart() {
        OnAppStart?.Invoke();
    }

    public void BroadcastAppExit() {
        OnAppExit?.Invoke();
    }

    /// <summary>Looks for an existing instance, if not found creates one. If multiple are found, reports error.</summary>
    private static void FindOrCreateInstance() {
        EventManager[] instanceArray = FindObjectsOfType<EventManager>();
        if (instanceArray.Length == 0) {
            instance = new GameObject("Event Manager").AddComponent<EventManager>();
        } else if (instanceArray.Length == 1) {
            instance = instanceArray[0];
        } else if (instanceArray.Length > 1) {
            Debug.LogError($"<color=yellow>Multiple instances of the singleton [EventManager] exists.</color>");
            Debug.Break();
        }
        DontDestroyOnLoad(instance);
    }
    #endregion
}