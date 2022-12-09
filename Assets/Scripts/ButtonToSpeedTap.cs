// Jenni
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToSpeedTap : MonoBehaviour {

    public void ChangeToSpeedTap() {
        SceneManager.LoadScene("SpeedTapLevel1", LoadSceneMode.Single);
    }
}