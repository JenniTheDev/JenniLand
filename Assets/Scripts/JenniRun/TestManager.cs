using UnityEngine;

public class TestManager : MonoBehaviour
{
    [field: SerializeField] public ScriptableObject JenniRunEventManager { get; private set; }

    void Awake() => DontDestroyOnLoad(this);
}