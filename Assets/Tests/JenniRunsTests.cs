using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class JenniRunsTests
{
    private GameObject player;
    private Gamepad gamepad;
    private Keyboard keyboard;
    private InputTestFixture inputTestFixture = new();

    [UnitySetUp]
    public IEnumerator Setup()
    {
        inputTestFixture.Setup();
        SceneManager.LoadScene("JenniRun");
        yield return new WaitForSeconds(2.0f);
        player = GameObject.FindGameObjectWithTag("Player");
        gamepad = InputSystem.AddDevice<Gamepad>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    [TearDown]
    public void TearDown()
    {
        player = null;
        gamepad = null;
        keyboard = null;
        inputTestFixture.TearDown();
    }

    [Test]
    public void CheckForJenniRunsSceneObjects()
    {
        AssertSceneLoaded("JenniRuns");
        var allObjects = Object.FindObjectsOfType<MonoBehaviour>();
        Debug.Log($"Object Count: {allObjects.Length}");
    }

    [Test]
    public void CheckNumberOfPlayers()
    {
        var playerList = GameObject.FindGameObjectsWithTag("Player");
        // any number but one player
        Assert.AreEqual(1, playerList.Length, "More then one player.");
    }

    [Test]
    public void PlayerHasAllPartsTest()
    {
        Assert.That(player, Is.Not.Null, "Player prefab is not found");
        Assert.That(player.GetComponent<Collider2D>(), Is.Not.Null, "Player is missing collider");
        Assert.That(player.GetComponent<Rigidbody2D>(), Is.Not.Null, "Player is missing rigidbody");
        Assert.That(player.GetComponent<JumpControl>(), Is.Not.Null, "Player input is missing");
    }

    [UnityTest]
    public IEnumerator PlayerGamePadJumpTest()
    {
        float jumpThreshhold = 0.1f;
        // Make sure you get the instance of the player, not a whole new player
        var playerInstance = GameObject.Find("Player");
        float startingPosition = playerInstance.transform.position.y;
        inputTestFixture.Press(gamepad.buttonSouth, 4);
        yield return new WaitForSeconds(1f);
        float endingPosition = playerInstance.transform.position.y;
        var jumpDistance = Mathf.Abs(endingPosition - startingPosition);

        Assert.IsFalse(jumpDistance < jumpThreshhold, "Player did not jump using gamepad.");
    }

    [UnityTest]
    public IEnumerator PlayerKeyboardJumpTest()
    {
        float jumpThreshhold = 0.1f;
        var playerInstance = GameObject.Find("Player");
        var startingPosition = playerInstance.transform.position.y;
        inputTestFixture.Press(keyboard.spaceKey, 4);
        yield return new WaitForSeconds(1f);
        float endingPosition = playerInstance.transform.position.y;
        var jumpDistance = Mathf.Abs(endingPosition - startingPosition);

        Assert.IsFalse(jumpDistance < jumpThreshhold, "Player did not jump using keyboard.");
    }

    [UnityTest]
    public IEnumerator CheckMaxFallVeloctyTest()
    {
        // jump a lot ?
        yield return new WaitForSeconds(1f);
    }

    [Test]
    public void SceneHasAllComponents()
    {
        // How do I get the camera object?
        var camera = GameObject.Find("Main Camera"); // is not found
        Assert.That(camera, Is.True, "Camera not found");
        Assert.That(player.gameObject, Is.Not.Null, "Player is missing");
    }

    [Test]
    public void StartButtonTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "Canvas not found");
        var startButton = canvas.transform.Find("StartButton").GetComponent<Button>();
        Assert.That(startButton, Is.Not.Null, "Start button not found");
    }

    [UnityTest]
    public IEnumerator StartTimerTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "Canvas not found");
        var startButton = canvas.transform.Find("StartButton").GetComponent<Button>();
        Assert.That(startButton, Is.Not.Null, "Start button not found");

        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        startButton.GetComponent<Button>().onClick.Invoke();
        // check that timer started
        yield return new WaitForSeconds(5f);
    }

    [UnityTest]
    public IEnumerator EndTimerTest()
    {
        yield return new WaitForSeconds(5f);
    }

    // This needs to be moved to a helper class
    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        var waitForScene = new WaitForSceneLoaded(sceneName);
        yield return waitForScene;
        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }
}