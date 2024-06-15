using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D colider;
    private float time;
    [SerializeField]
    private LayerMask mask;

    protected bool jump;
    protected bool jumpHeld;
    protected float move;

    private bool useJump;
    private bool doubleJumpUsed;
    private float whenJumpPressed;
    private float whenGroudedStoped;
    private bool bufferedJumpAvailable;
    private bool coyoteTimeAvailable;
    private bool endedJumpEarly;
    private bool grounded;
    private bool lookingRight;

    private Vector2 velocity;

    [SerializeField]
    private float distanceForGrounded = 0.05f;
    [SerializeField]
    private float bufferer = 0.07f;
    [SerializeField]
    private float coyoteTime = 0.07f;
    [SerializeField]
    private float jumpForce = 25;
    [SerializeField]
    private float doubleJumpForce = 20;

    [SerializeField]
    private float groundDeceleration = 70;
    [SerializeField]
    private float airDeceleration = 60;
    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float acceleration = 100;

    [SerializeField]
    private float groundedGravity = -1.5f;
    [SerializeField]
    private float gravity = 65;
    [SerializeField]
    private float maxFallSpeed = 20;
    [SerializeField]
    private float endedJumpEarlyGravityMultyplier = 3;

    private void OnEnable()
    {
        time = 0;
        move = 0;
        jump = false;
        useJump = false;
        jumpHeld = false;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();
        Physics2D.queriesStartInColliders = false;
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        GetInputs();
        HandleCollisions();
        HandleJumps();
        HandleXVelocity();
        HandleYVelocity();
        rb.velocity = velocity;
    }

    private void GetInputs()
    {
        if (jump)
        {
            jump = false;
            useJump = true;
            whenJumpPressed = time;
        }

        if (move < 0)
        {
            lookingRight = false;
        }
        else if (move > 0)
        {
            lookingRight = true;
        }
    }

    private void HandleCollisions()
    {
        bool groundCollision = Physics2D.BoxCast(transform.position, colider.size, 0, Vector2.down, distanceForGrounded, ~mask);
        bool ceilingCollision = Physics2D.BoxCast(transform.position, colider.size, 0, Vector2.up, distanceForGrounded, ~mask);

        if (ceilingCollision)
        {
            velocity.y = Mathf.Min(0, velocity.y);
        }

        if (!grounded && groundCollision)
        {
            grounded = true;
            coyoteTimeAvailable = true;
            bufferedJumpAvailable = true;
            endedJumpEarly = false;
            doubleJumpUsed = false;
        }

        else if (!groundCollision && grounded)
        {
            grounded = false;
            whenGroudedStoped = time;
        }
    }

    private void HandleJumps()
    {
        if (!endedJumpEarly && !grounded && !jumpHeld && rb.velocity.y > 0)
        {
            endedJumpEarly = true;
        }

        if (useJump)
        {
            if (bufferedJumpAvailable && time < whenJumpPressed + bufferer)
            {
                if (grounded || coyoteTimeAvailable && time < whenGroudedStoped + coyoteTime)
                {
                    Jump();
                }
            }
            else
            {
                if (!doubleJumpUsed)
                {
                    DoubleJump();
                }
                else
                {
                    useJump = false;
                }
            }
        }
    }

    private void Jump()
    {
        useJump = false;
        endedJumpEarly = false;
        bufferedJumpAvailable = false;
        coyoteTimeAvailable = false;
        velocity.y = jumpForce;
    }

    private void DoubleJump()
    {
        endedJumpEarly = false;
        velocity.y = doubleJumpForce;
        doubleJumpUsed = true;
    }

    private void HandleXVelocity()
    {
        if (move == 0)
        {
            float deceleration = grounded ? groundDeceleration : airDeceleration;
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.fixedDeltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, move * maxSpeed, acceleration * Time.fixedDeltaTime);
        }
    }

    private void HandleYVelocity()
    {
        if (grounded && velocity.y <= 0)
        {
            velocity.y = groundedGravity;
        }

        else
        {
            float currentGravity = gravity;
            if (endedJumpEarly && velocity.y > 0)
            {
                currentGravity *= endedJumpEarlyGravityMultyplier;
            }
            velocity.y = Mathf.MoveTowards(velocity.y, -maxFallSpeed, currentGravity * Time.fixedDeltaTime);
        }
    }

    public bool GetDirection()
    {
        return lookingRight;
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        float newMove = input.ReadValue<Vector2>().x;
        move = newMove;
    }

    public void OnJump(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
            jump = true;
            jumpHeld = true;
        }
        else if (input.canceled)
        {
            jumpHeld = false;
        }
    }
}
