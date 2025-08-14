
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float stopDistance = 1f; // How close to get to player before stopping

    [Header("Knockback")]
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.3f;

    [Header("References")]
    private Transform player;
    private Rigidbody2D rb;
    private bool isKnockedBack = false;

    void Start()
    {
        // Find the player automatically
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No GameObject with 'Player' tag found!");
        }

        // Get rigidbody component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Enemy needs a Rigidbody2D component!");
        }
    }

    void Update()
    {
        if (player == null || isKnockedBack) return;

        MoveTowardPlayer();
    }

    void MoveTowardPlayer()
    {
        // Calculate direction to player
        Vector2 direction = (player.position - transform.position).normalized;

        // Check distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Only move if farther than stop distance
        if (distanceToPlayer > stopDistance)
        {
            // Move toward player
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            // Stop moving when close enough
            rb.linearVelocity = Vector2.zero;
        }

        // Optional: Flip sprite based on direction
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
    }

    public void ApplyKnockback(Vector2 knockbackDirection)
    {
        if (rb == null) return;

        StartCoroutine(KnockbackCoroutine(knockbackDirection));
    }

    IEnumerator KnockbackCoroutine(Vector2 direction)
    {
        isKnockedBack = true;

        // Apply knockback force
        rb.linearVelocity = direction * knockbackForce;

        // Wait for knockback duration
        yield return new WaitForSeconds(knockbackDuration);

        // Resume normal movement
        isKnockedBack = false;
    }
}