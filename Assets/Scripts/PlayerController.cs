using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 3f;

    private UserInputs input;
    private InputAction move;
    private InputAction jump;

    private Transform cachedTransform;

    public void Awake()
    {
        cachedTransform = transform;
        input = new UserInputs();
        rb = GetComponent<Rigidbody2D>();
        move = input.Player.Move;
        jump = input.Player.Jump;
    }

    public void Update()
    {
    }

    private void OnEnable()
    {
        move.started += OnMoveStarted;
        move.canceled += OnMoveStopped;
        move.Enable();

        jump.started += OnJump;
        jump.Enable();
    }

    private void OnDisable()
    {
        move.started -= OnMoveStarted; // action type value
        move.canceled -= OnMoveStopped;
        move.Enable();

        jump.started -= OnJump; //Action type button
        jump.Disable();
    }

    private void OnMoveStarted(InputAction.CallbackContext ctx)
    {
    }

    private void OnMoveStopped(InputAction.CallbackContext ctx)
    {
        // probably don't need this
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
    }
}