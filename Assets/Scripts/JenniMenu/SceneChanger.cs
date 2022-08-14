using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToJenniSays()
    {
        SceneManager.LoadScene("JenniSays", LoadSceneMode.Single);
    }

    public void ChangeToJenniRun()
    {
        SceneManager.LoadScene("JenniRun", LoadSceneMode.Single);
    }

    public void ChangeToJenniJump()
    {
        SceneManager.LoadScene("JenniJump", LoadSceneMode.Single);
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("JenniMenu", LoadSceneMode.Single);
    }
}