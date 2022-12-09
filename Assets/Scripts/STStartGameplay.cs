// Jenni
using UnityEngine;

public class STStartGameplay : MonoBehaviour
{
    public void StartGame() {
        STEventManager.Instance.BroadcastGameStart();

    }


    
}
