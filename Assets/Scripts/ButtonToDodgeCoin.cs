using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToDodgeCoin : MonoBehaviour {

    public void ChangeToDodgeCoin() {
        SceneManager.LoadScene("DodgeCoin", LoadSceneMode.Single);
    }
}