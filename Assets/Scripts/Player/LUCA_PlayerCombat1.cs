using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class LUCA_PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public bool attacking = false;
    public LayerMask enemyLayers;
    public static float vidaActual = 100;
    public int asljdb = 0; 
    
    void FixedUpdate()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (attacking == false)
            {
                if (Time.deltaTime - asljdb >= 50)
                {
                    Attack();
                }
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void RemoveLife (int damage) {

        vidaActual = vidaActual - damage;

    }

}
