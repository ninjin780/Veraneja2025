using System;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator animator;
    public Transform player;
    
    public float groundSpeed;
    public float drag;

    private float encojer = 0.95f, agrandar = 1.05f;
    private float posicionY = -3;
    
    private float xInput;
    private float yInput;
    
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
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
            playerRb.linearVelocity = new Vector2(xInput * groundSpeed, playerRb.linearVelocity.y);
            Flip();
        }
        animator.SetFloat("movement", playerRb.linearVelocity.x);
    }
    void HandleYMovement()
    {
        if (yInput != 0)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, yInput * groundSpeed);
            animator.SetFloat("movement", playerRb.linearVelocity.y);
            CambioEscala();
        }
        
    }
    void Flip()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(player.localScale.y * direction, player.localScale.y, 1);
    }
    void ApplyFriction()
    {
        if (xInput == 0  && yInput == 0)
        {
            playerRb.linearVelocity *= drag;
        }
    }

    void CambioEscala()
    {
        if (yInput < 0 && player.localScale.y < 1 && playerRb.position.y < posicionY)
        {
            player.localScale = new Vector3(player.localScale.x * agrandar, player.localScale.y * agrandar, 1);
        }
        else if (yInput > 0 && player.localScale.y >= 0.6 && playerRb.position.y > posicionY)
        {
            player.localScale = new Vector3(player.localScale.x * encojer, player.localScale.y * encojer, 1);
        }
    }
}
