using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private Vector3 position;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            position = collision.gameObject.GetComponent<Transform>().localPosition;
            Debug.Log("Damage");
            collision.gameObject.GetComponent<PlayerCombat>().RemoveLife(3); 
            if (position.x >= 0)
            {
                position = new Vector3(position.x - 25, position.y, 1);
            }
            else
            {
                position = new Vector3(position.x + 25, position.y, 1); 
            }
            
        }
    }

    void recieveDamage()
    {

    }
}
