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
    private Gamepad gamepad;
    private Keyboard keyboard;
    private InputTestFixture inputTestFixture = new();

    [SetUp]
    public void Setup()
    {
        inputTestFixture.Setup();
        SceneManager.LoadScene("JenniMenu");
        gamepad = InputSystem.AddDevice<Gamepad>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    [TearDown]
    public void TearDown()
    {
        gamepad = null;
        keyboard = null;
        inputTestFixture.TearDown();
    }

    [UnityTest]
    public IEnumerator CheckForUiCanvasTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.IsNotNull(canvas);
        yield return null;
    }

    // Write these to be a method that IEnumerates a list of buttons
    [UnityTest]
    public IEnumerator CheckForJenniSaysButtonTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "UI canvas not found.");
        var button = canvas.transform.Find("JenniSaysButton").GetComponent<Button>();
        Assert.That(button, Is.Not.Null, "JenniSays button not found.");

        EventSystem.current.SetSelectedGameObject(button.gameObject);

        button.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSceneLoaded("JenniSays");
        AssertSceneLoaded("JenniSays");
        var scene = SceneManager.GetActiveScene().name;
        Assert.AreEqual(scene, "JenniSays", "JenniSays button did not open JenniSays scene.");
        AssertSceneLoaded("JenniSays");
    }

    [UnityTest]
    public IEnumerator CheckForJenniRunButtonTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "UI canvas not found.");
        var button = canvas.transform.Find("JenniRunButton").GetComponent<Button>();
        Assert.That(button, Is.Not.Null, "JenniRun button not found.");

        EventSystem.current.SetSelectedGameObject(button.gameObject);

        button.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSceneLoaded("JenniRun");
        AssertSceneLoaded("JenniRun");
        var scene = SceneManager.GetActiveScene().name;
        Assert.AreEqual(scene, "JenniRun", "JenniRun button did not open JenniRun scene.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckForJenniJumpButtonTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "UI canvas not found.");
        var button = canvas.transform.Find("JenniJumpButton").GetComponent<Button>();
        Assert.That(button, Is.Not.Null, "JenniJump button not found.");

        EventSystem.current.SetSelectedGameObject(button.gameObject);

        button.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSceneLoaded("JenniJump");
        AssertSceneLoaded("JenniJump");
        var scene = SceneManager.GetActiveScene().name;
        Assert.AreEqual(scene, "JenniJump", "JenniJump button did not open JenniJump scene.");
    }

    [Test]
    public void CheckForJenniSaysSceneObjects()
    {
        AssertSceneLoaded("JenniMenu");
        var allObjects = Object.FindObjectsOfType<MonoBehaviour>();
        Debug.Log($"Object Count: {allObjects.Length}");
    }

    [UnityTest]
    public IEnumerator TestSceneChangeToMainMenu()
    {
        GameObject gameObject = new GameObject();
        var sceneChanger = gameObject.AddComponent(typeof(SceneChanger)) as SceneChanger;
        AssertSceneLoaded("JenniSays");
        sceneChanger.ChangeToMainMenu();
        AssertSceneLoaded("JenniMenu");
        yield return null;
    }

    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        var waitForScene = new WaitForSceneLoaded(sceneName);
        yield return waitForScene;
        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }
}