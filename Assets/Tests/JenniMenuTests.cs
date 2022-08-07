using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class JenniMenuTests
{
    private GameObject player;
    private Gamepad gamepad;
    private Keyboard keyboard;
    private InputTestFixture inputTestFixture = new();

    [SetUp]
    public void Setup()
    {
        // load my prefabs and stuff here if I need them a lot
        inputTestFixture.Setup();
        SceneManager.LoadScene("JenniMenu");
        player = Resources.Load<GameObject>("Prefabs/Player");
        gamepad = InputSystem.AddDevice<Gamepad>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    [TearDown]
    public void TearDown()
    {
        // tear down clean up stuff between tests, set prefabs to null
        player = null;
        gamepad = null;
        keyboard = null;
        inputTestFixture.TearDown();
    }

    [Test]
    public void CheckForJenniSaysButtonsTest()
{
        var canvas = GameObject.Find("Canvas"); // cant find canvas
        var button = canvas.transform.Find("JenniSaysButton"); // can't find
        Assert.IsNotNull(button, "Missing button " + "JenniSaysButton");
       

        // Set it selected for the Event System
        EventSystem.current.SetSelectedGameObject(button.gameObject);

        // Invoke click
        button.GetComponent<Button>().onClick.Invoke();
        var scene = SceneManager.GetSceneByName("JenniSays");
        Assert.AreEqual(scene, "JenniSays", "JenniSays button did not open JenniSays scene.");
        AssertSceneLoaded("JenniSays");
    }

    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        var waitForScene = new WaitForSceneLoaded(sceneName);
        yield return waitForScene;
        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }

}