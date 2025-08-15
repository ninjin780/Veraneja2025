using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MovementEnemy : MonoBehaviour
{
    private PlayerMovement pm;
    private Transform player;
    private Transform enemy;
    private Vector3 playerPosition;
    public Rigidbody2D enemyRb;

    public float groundSpeed;
    public float drag;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // Mover
        transform.position = Vector2.MoveTowards(transform.position, player.position, groundSpeed * drag);
    }
}
