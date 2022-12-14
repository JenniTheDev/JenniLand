using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class JumpControl : MonoBehaviour
{
    private const float SNAP_VELOCITY = -0.1f;
    private const float MAX_FALL_VELOCITY = -1.0f;
    private const float GROUND_BUFFER = 0.5f;

    [SerializeField] private float jumpForce;
    [SerializeField] private float snapForce;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGrounded => Physics2D.Raycast(playerCollider.transform.position, Vector2.down, JumpCheckDistance, groundLayer);

    private float DistToFloor => playerCollider.bounds.extents.y;
    private float JumpCheckDistance => DistToFloor + GROUND_BUFFER;

    private Rigidbody2D rBody;
    private Transform cachedTransform;
    private Collider2D playerCollider;

    private UserInputs input;
    private InputAction jump;

    private void Awake()
    {
        cachedTransform = transform;
        rBody = GetComponent<Rigidbody2D>();

        input = new UserInputs();
        jump = input.Player.Jump;
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        CheckJumpVelocity();
    }

    private void Jump()
    {
        if (IsGrounded)
        {
            rBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void CheckJumpVelocity()
    {
        if (IsFalling() && IsAboveMaxFallVelocity())
        {
            rBody.AddForce(snapForce * Time.deltaTime * Vector3.down, ForceMode2D.Impulse);
        }

        bool IsFalling() => rBody.velocity.y < SNAP_VELOCITY;
        bool IsAboveMaxFallVelocity() => rBody.velocity.y > MAX_FALL_VELOCITY;
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        Jump();
    }

    private void OnEnable()
    {
        jump.started += OnJump;
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.started -= OnJump;
        jump.Disable();
    }
}