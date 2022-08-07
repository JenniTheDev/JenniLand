using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class JenniRunsTests
{
    private GameObject player;

    [SetUp]
    public void Setup()
    {
        // load my prefabs and stuff here if I need them a lot
        SceneManager.LoadScene("JenniRun");
        player = Resources.Load<GameObject>("Prefabs/Player");
    }

    [TearDown]
    public void TearDown()
    {
        // tear down clean up stuff between tests, set prefabs to null
    }

    [Test]
    public void PlayerHasAllPartsTest()
    {
        Assert.That(player, Is.Not.Null, "Player prefab is not found");
    }

    [Test]
    public void SceneHasAllComponents()
    {
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator JenniRunsTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}