using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private Vector3 position;

    public int maxHp = 30;
    public int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            position = collision.gameObject.GetComponent<Transform>().localPosition;
            Debug.Log("Damage");
            collision.gameObject.GetComponent<PlayerCombat>().RemoveLife(3); 
            if (position.x >= 0)
            {
                position = new Vector3(position.x - 1.5f, position.y, position.z);
                collision.gameObject.GetComponent<Transform>().localPosition = position;
            }
            else
            {
                position = new Vector3(position.x + 1.5f, position.y, position.z); 
                collision.gameObject.GetComponent<Transform>().localPosition = position;
            }
            
        }
    }

    public void recieveDamage(int dmg)
    {

        currentHp -= dmg;

        if (currentHp <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        Debug.Log("monstro has died");
       

    }
}
