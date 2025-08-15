using UnityEngine;

public class MovimientoGrande : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Animator animator;
    public Transform player;
    
    public float groundSpeed;
    public float drag;
    
    private float xInput;

    void Update()
    {
        CheckInput();
    }
    void FixedUpdate()
    {
        HandleXMovement();
        ApplyFriction();
    }
    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
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
    void Flip()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(player.localScale.y * direction, player.localScale.y, 1);
    }
    void ApplyFriction()
    {
        if (xInput == 0)
        {
            playerRb.linearVelocity *= drag;
        }
    }
}
