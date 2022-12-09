using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Inspired by: https://www.youtube.com/watch?v=zc8ac_qUXQY&t=1s
*/
public class MainMenu : MonoBehaviour
{
  // Script for button to move to swipe menu
   public void ToSwipeMenu() {
       SceneManager.LoadScene("SwipeMenu", LoadSceneMode.Single);
   }

  //allows user to quit the application 
  public void QuitGame ()
  {
    Debug.Log("QUIT!");
    //closes program
    Application.Quit();
  }
}
