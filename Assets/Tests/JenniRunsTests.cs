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
        Assert.That(player.GetComponent<JumpControl>(), Is.Not.Null, "Player input is missing");
    }

    [UnityTest]
    public IEnumerator PlayerGamePadJumpTest()
    {
        var startingPosition = player.transform.position.y;
        inputTestFixture.Press(gamepad.buttonSouth, 4);
        yield return new WaitForSeconds(1f);
        var endingPosition = player.transform.position.y;
        Assert.That(endingPosition, Is.Not.EqualTo(startingPosition), "Player did not jump using gamepad.");
    }

    [UnityTest]
    public IEnumerator PlayerKeyboardJumpTest()
    {
        var startingPosition = player.transform.position.y;
        inputTestFixture.Press(keyboard.spaceKey, 4);
        yield return new WaitForSeconds(0.5f);
        var endingPosition = player.transform.position.y;
        Assert.That(endingPosition, Is.GreaterThan(startingPosition), "Player did not jump using keyboard.");
    }

    [Test]
    public void SceneHasAllComponents()
    {
        // How do I get the camera object?
        // Assert.That(Assets)
        Assert.That(player.gameObject, Is.Not.Null, "Player is missing");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator JenniRunsTestsWithEnumeratorPasses()
    // {
    // Use the Assert class to test conditions.
    // Use yield to skip a frame.
    //    yield return null;
    // }
}