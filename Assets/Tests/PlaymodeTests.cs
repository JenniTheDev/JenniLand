using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlaymodeTests
{
    [Test]
    public void SceneLoadingTest()
    {
        SceneManager.LoadScene("Scenes/JenniMenu");
    }
}