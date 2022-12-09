using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSwipeButton : MonoBehaviour {

    public void ToMainMenu() {
        SceneManager.LoadScene("SwipeMenu", LoadSceneMode.Single);
    }
}