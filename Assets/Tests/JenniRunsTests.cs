using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class JenniRunsTests
{
    private GameObject player;
    private Gamepad gamepad;
    private Keyboard keyboard;
    private InputTestFixture inputTestFixture = new();

    [SetUp]
    public void Setup()
    {
        inputTestFixture.Setup();
        SceneManager.LoadScene("JenniRun");
        player = Resources.Load<GameObject>("Prefabs/Player");
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
        var startingPosition = player.transform.position.y;
        inputTestFixture.Press(gamepad.buttonSouth, 4);
        yield return new WaitForSeconds(1f);
        // I think the ending position is getting the transform at the wrong time
        var endingPosition = player.transform.position.y;
        // The positions are always the same
        Assert.That(endingPosition, Is.Not.EqualTo(startingPosition), "Player did not jump using gamepad.");
    }

    [UnityTest]
    public IEnumerator PlayerKeyboardJumpTest()
    {
        var startingPosition = player.transform.position.y;
        inputTestFixture.Press(keyboard.spaceKey, 4);
        var endingPosition = player.transform.position.y;
        yield return new WaitForSeconds(0.5f);
        Assert.That(endingPosition, Is.GreaterThan(startingPosition), "Player did not jump using keyboard.");
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

    // This needs to be moved to a helper class
    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        var waitForScene = new WaitForSceneLoaded(sceneName);
        yield return waitForScene;
        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }
}