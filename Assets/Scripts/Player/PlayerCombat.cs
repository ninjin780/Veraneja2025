using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public bool attacking = false;
    public LayerMask enemyLayers;
    public static float vidaActual = 100;
    public int lastAttack = 0;
    public int time = 0;
    public int attackDamage = 10;

    private void FixedUpdate()
    {
        time++;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (time - lastAttack > 50)
            {
                lastAttack = time;
                Attack();
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
            enemy.GetComponent<DamagePlayer>().recieveDamage(attackDamage);

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
