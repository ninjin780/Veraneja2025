using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    void Start()
    {
        
    }

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(xInput) > 0)
        {
            playerRb.linearVelocity = new Vector2(xInput * speed, playerRb.linearVelocity.y);
        }

        if (Mathf.Abs(yInput) > 0)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, yInput * speed);
        }
    }
}
