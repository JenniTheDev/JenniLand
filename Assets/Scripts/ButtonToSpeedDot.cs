using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToSpeedDot : MonoBehaviour {

    public void ChangeToSpeedDot() {
        SceneManager.LoadScene("SpeedDot", LoadSceneMode.Single);
    }
}