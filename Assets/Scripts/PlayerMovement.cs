using System;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public Animator animator;
    
    public float groundSpeed;
    public float jumpSpeed;
    public float drag;
    
    public bool grounded;
    
    private float xInput;
    private float yInput;

    void Update()
    {
        CheckInput();
        HandleJump();
    }

    private void FixedUpdate()
    {
        CheckGround();
        HandleXMovement();
        HandleYMovement();
        ApplyFriction();
    }
    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }
    void HandleXMovement()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            playerRb.linearVelocity = new Vector2(xInput * groundSpeed,playerRb.linearVelocity.y);
            Flip();
        }
        animator.SetFloat("movement", playerRb.linearVelocity.x);
    }
    void HandleYMovement()
    {
        if (Mathf.Abs(yInput) > 0)
        {
            playerRb.linearVelocity = new Vector2(xInput * groundSpeed,playerRb.linearVelocity.y);
            Flip();
        }
        animator.SetFloat("movement", playerRb.linearVelocity.x);
    }
    

    void Flip()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void HandleJump()
    {
        if (Mathf.Abs(yInput) > 0 && grounded)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, yInput * jumpSpeed);
        }
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0  && playerRb.linearVelocity.y <= 0)
        {
            playerRb.linearVelocity *= drag;
        }
    }

    private void CheckGround()
    {  
       grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;  
    }
}
