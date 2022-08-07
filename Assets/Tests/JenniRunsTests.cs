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
        // load my prefabs and stuff here if I need them a lot
        inputTestFixture.Setup();
        SceneManager.LoadScene("JenniRun");
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
        // yield return new WaitForSeconds(0.5f);
        var endingPosition = player.transform.position.y;
        yield return new WaitForSeconds(0.5f);
        Assert.That(endingPosition, Is.GreaterThan(startingPosition), "Player did not jump using keyboard.");
    }

    [UnityTest]
    public IEnumerator CheckMaxFallVeloctyTest()
    {
        // jump a lot ?
        yield return new WaitForSeconds(10f);
    }

    [Test]
    public void SceneHasAllComponents()
    {
        // How do I get the camera object?
        // var camera = Camera.main.enabled;
        // Assert.That(camera, Is.True, "Camera not found");
        Assert.That(player.gameObject, Is.Not.Null, "Player is missing");
    }
}