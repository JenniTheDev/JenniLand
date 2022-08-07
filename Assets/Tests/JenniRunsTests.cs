using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
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
        // load my prefabs and stuff here if I need them a lot
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
        // tear down clean up stuff between tests, set prefabs to null
    }

    [Test]
    public void PlayerHasAllPartsTest()
    {
        Assert.That(player, Is.Not.Null, "Player prefab is not found");
        Assert.That(player.GetComponent<Collider2D>(), Is.Not.Null, "Player is missing collider");
        Assert.That(player.GetComponent<Rigidbody2D>(), Is.Not.Null, "Player is missing rigidbody");
        Assert.That(player.GetComponent<PlayerInput>(), Is.Not.Null, "Player input is missing");
    }

    [Test]
    public void PlayerMovementXAxisTest()
    {
        var startingPosition = player.transform.position.x;
        inputTestFixture.Press(gamepad.leftStick.right);
        inputTestFixture.Set(gamepad.leftStick, new Vector2(1, 0));
        var endingPosition = player.transform.position.x;
        Assert.That(endingPosition, Is.GreaterThan(startingPosition), "Player did not move using gamepad.");

        inputTestFixture.Press(keyboard.dKey, 10);

        endingPosition = player.transform.position.x;
        Assert.That(endingPosition, Is.GreaterThan(startingPosition), "Player did not move using keyboard.");
    }

    public void PlayerMovementJumpTest()
    {
    }

    [Test]
    public void SceneHasAllComponents()
    {
        // How do I get the camera object?
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