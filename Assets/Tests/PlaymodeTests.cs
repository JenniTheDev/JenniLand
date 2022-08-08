using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEditor.TestTools;
using UnityEngine.InputSystem;

public class PlaymodeTests
{
    // This should be an edit mode test?, but when I put it in edit mode
    // It doesn't see UserData as a class
    // It only sees it as a class in Playmode with the assembly in Assets folder
    [Test]
    public void UserDataTest()
    {
        var userData = new UserData(42, "TestUser");
        Assert.That(userData.Id, Is.EqualTo(42), "Id is wrong.");
        Assert.That(userData.UserName, Is.EqualTo("TestUser"), "User name is wrong.");
    }

    // Trying to test Wait For Scene loaded but it doesn't show up as covered on the report
    public void WaitForSceneLoadedTest()
    {
        var testScene = new WaitForSceneLoaded("JenniJump", 8);
        Assert.That(testScene, Is.Not.Null, "Test Scene loaded");
    }
}