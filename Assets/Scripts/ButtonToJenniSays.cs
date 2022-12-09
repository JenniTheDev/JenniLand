using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToJenniSays : MonoBehaviour {

    public void ChangeToJenniSays() {
        SceneManager.LoadScene("Jenni Says", LoadSceneMode.Single);
    }
}