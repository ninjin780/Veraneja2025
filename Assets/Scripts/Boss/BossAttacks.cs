using System;
using System.Collections;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    [Header("Referencias")]
    public Animator animator;
    public BoxCollider2D rightAttack;
    public BoxCollider2D leftAttack;
    
    [Header("Configuración")]
    public int lifes = 15;
    public float attackSpeed = 0.1f;
    public float maxAttackSize = 14f;
    public float attackDuration = 0.1f;
    
    private AnimatorClipInfo[] animation;
    private string currentClipName = "";
    private string previousClipName = "";
    private bool isAttacking = false;
    
    void Start()
    {
        // Inicializar colliders desactivados
        rightAttack.enabled = false;
        leftAttack.enabled = false;
        
        // Resetear tamaños iniciales
        rightAttack.size = Vector2.one;
        leftAttack.size = Vector2.one;
    }
    
    void Update()
    {
        CheckAnimationState();
    }
    
    private void CheckAnimationState()
    {
            // Obtener información de la animación actual
            animation = animator.GetCurrentAnimatorClipInfo(0);
            
            // Verificar si hay clips disponibles
            if (animation.Length > 0)
            {
                currentClipName = animation[0].clip.name;
                
                // Solo ejecutar ataques cuando cambie la animación y no esté atacando
                if (currentClipName != previousClipName && !isAttacking)
                {
                    HandleAttackAnimation(currentClipName);
                    previousClipName = currentClipName;
                }
            }
    }
    
    private void HandleAttackAnimation(string clipName)
    {
        switch (clipName)
        {
            case "Ataque1":
                StartCoroutine(AttackRight());
                break;
            case "Ataque2":
                StartCoroutine(AttackLeft());
                break;
        }
    }
    
    IEnumerator AttackRight()
    {
        if (isAttacking) yield break; // Evitar múltiples ataques simultáneos
        
        isAttacking = true;
        rightAttack.enabled = true;
        
        // Expandir el collider gradualmente
        while (rightAttack.size.x < maxAttackSize)
        {
            rightAttack.size = new Vector2(rightAttack.size.x + attackSpeed, rightAttack.size.y);
            yield return null;
        }
        
        // Mantener el ataque activo por un tiempo
        yield return new WaitForSeconds(attackDuration);
        
        // Resetear el collider
        rightAttack.enabled = false;
        rightAttack.size = Vector2.one;
        
        isAttacking = false;
    }
    
    IEnumerator AttackLeft()
    {
        if (isAttacking) yield break; // Evitar múltiples ataques simultáneos
        
        isAttacking = true;
        leftAttack.enabled = true;
        
        // Expandir el collider gradualmente
        while (leftAttack.size.x < maxAttackSize)
        {
            leftAttack.size = new Vector2(leftAttack.size.x + attackSpeed, leftAttack.size.y);
            yield return null;
        }
        
        // Mantener el ataque activo por un tiempo
        yield return new WaitForSeconds(attackDuration);
        
        // Resetear el collider
        leftAttack.enabled = false;
        leftAttack.size = Vector2.one;
        
        isAttacking = false;
    }
    
    // Método público para forzar detener todos los ataques
    public void StopAllAttacks()
    {
        StopAllCoroutines();
        rightAttack.enabled = false;
        leftAttack.enabled = false;
        rightAttack.size = Vector2.one;
        leftAttack.size = Vector2.one;
        isAttacking = false;
    }
    
    // Método para recibir daño (usando la variable lifes)
    public void TakeDamage(int damage = 1)
    {
        lifes -= damage;
        Debug.Log($"Jefe recibió daño. Vidas restantes: {lifes}");
        
        if (lifes <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("El jefe ha sido derrotado!");
        StopAllAttacks();
        // Aquí puedes añadir lógica de muerte (animación, sonidos, etc.)
    }
}