using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damage");
            collision.gameObject.GetComponent<PlayerCombat>().RemoveLife(3);
        }
    }

    void recieveDamage()
    {

    }
}
