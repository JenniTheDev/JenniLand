using System.Collections;
using NUnit.Framework;
using TMPro;
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

    [Test]
    public void ObstacleHasAllPartsTest()
    {
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
        var camera = Camera.main;
        Assert.That(camera, Is.Not.Null, "Camera not found");
        Assert.That(player.gameObject, Is.Not.Null, "Player is missing");
        var gameManager = GameObject.Find("JenniRunEventManager"); // Not found
        Assert.That(gameManager, Is.Not.Null, "Game manager not found.");
    }

    [Test]
    public void FindStartButtonTest()
    {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "Canvas not found");
        var startButton = canvas.transform.Find("StartButton").GetComponent<Button>();
        Assert.That(startButton, Is.Not.Null, "Start button not found");
    }

    [UnityTest]
    public IEnumerator StartTimerWithStartButtonTest()
    {
        // tests should still work if the design changes and the code doesn't
        // tags ok for tests
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "Canvas not found");
        var startButton = canvas.transform.Find("StartButton").GetComponent<Button>();
        Assert.That(startButton, Is.Not.Null, "Start button not found");

        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        startButton.GetComponent<Button>().onClick.Invoke();

        var timer = canvas.transform.Find("Timer");
        Assert.That(timer, Is.Not.Null, "Can't find timer.");
        var time = timer.gameObject.GetComponent<TMP_Text>().text;
        yield return new WaitForSeconds(5f);
        var timePassed = timer.gameObject.GetComponent<TMP_Text>().text;
        Assert.IsTrue(time != timePassed, "Time did not advance.");
    }

    [UnityTest]
    public IEnumerator GameStartEventTest()
    {
        var manager = GameObject.FindObjectOfType<TestManager>();
        Assert.That(manager, Is.Not.Null, "Can't find Test manager.");
        yield return new WaitForSeconds(5f);
    }

    [UnityTest]
    public IEnumerator EndTimerTest()
    {
        yield return new WaitForSeconds(5f);
    }

    [Test]
    public void CheckIfObstacleColliderWorks()
    {
        // check if collider exists
    }

    [Test]
    public void CheckIfSpawnerStartsSpawning()
    {
    }

    [Test]
    public void GameOverOnCollisionTest()
    {
    }

    // This needs to be moved to a helper class
    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        var waitForScene = new WaitForSceneLoaded(sceneName);
        yield return waitForScene;
        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }
}