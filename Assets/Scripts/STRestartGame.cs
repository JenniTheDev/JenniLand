// Jenni
using UnityEngine;

public class STRestartGame : MonoBehaviour
{
   public void RestartGame() {
        STEventManager.Instance.BroadcastGameStart();

    }
}
