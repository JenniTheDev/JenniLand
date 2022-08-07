using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEditor.TestTools;

public class PlaymodeTests
{
    // This should be an edit mode test, but when I put it in edit mode
    // It doesn't see UserData as a class
    // It only sees it as a class in Playmode with the assembly in Assets folder
    [Test]
    public void UserDataTest()
    {
        var userData = new UserData(69, "TestUser");
        Assert.That(userData.Id, Is.EqualTo(69), "Id is wrong.");
        Assert.That(userData.UserName, Is.EqualTo("TestUser"), "User name is wrong.");
    }
}