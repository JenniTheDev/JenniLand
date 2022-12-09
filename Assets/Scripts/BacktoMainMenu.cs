using UnityEngine;
using UnityEngine.SceneManagement;

//Takes you back to Main Menu when you click on the
public class BacktoMainMenu : MonoBehaviour {

    // Script for back button and return to main menu
    public void ToMainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
