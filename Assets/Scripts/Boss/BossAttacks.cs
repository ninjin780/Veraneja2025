using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAttacks : MonoBehaviour
{
    [Header("Referencias de Animación")]
    public Animator animator;
    public BoxCollider2D rightAttack;
    public BoxCollider2D leftAttack;
    
    [Header("Referencias del Jugador")]
    public PlayerCombat playerCombat;
    public GameObject currentPlayer;
    private float health;
    
    [Header("Configuración del Jefe")]
    public int lifes = 35;
    public float attackSpeed = 0.1f;
    public float maxAttackSize = 14f;
    public float attackDuration = 0.1f;
    public int damageAmount = 35;
    
    private AnimatorClipInfo[] animation;
    private string currentClipName = "";
    private string previousClipName = "";
    private bool isAttacking = false;
    private bool canDamagePlayer = true;
    private float damageCD = 1f; // Cooldown para evitar daño spam
    
    void Start()
    {
        health = playerCombat.GetCurrentHealth();
        InitializeBoss();
        FindPlayerReferences();
    }
    
    private void InitializeBoss()
    {
        // Inicializar colliders desactivados
        rightAttack.enabled = false;
        leftAttack.enabled = false;
        
        // Resetear tamaños iniciales
        rightAttack.size = Vector2.one;
        leftAttack.size = Vector2.one;
        
        // Configurar colliders como triggers si no lo están
        rightAttack.isTrigger = true;
        leftAttack.isTrigger = true;
    }
    
    private void FindPlayerReferences()
    {
        // Buscar el jugador actual si no está asignado
        if (currentPlayer == null)
        {
            currentPlayer = GameObject.FindGameObjectWithTag("Player");
        }
        
        if (playerCombat == null && currentPlayer != null)
        {
            playerCombat = currentPlayer.GetComponent<PlayerCombat>();
        }
        
        if (currentPlayer == null || playerCombat == null)
        {
            Debug.LogWarning("[BossAttacks] No se encontró el jugador o PlayerCombat. Asegúrate de que el jugador tenga el tag 'Player' y el componente PlayerCombat.");
        }
    }
    
    void Update()
    {
        CheckAnimationState();
        
        // Re-buscar jugador si se perdió la referencia (útil cuando cambia de jugador)
        if (currentPlayer == null || !currentPlayer.activeInHierarchy)
        {
            FindPlayerReferences();
        }
    }
    
    private void CheckAnimationState()
    {
        if (animator == null) return;
        
        try
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
        catch (Exception e)
        {
            Debug.LogError($"Error al obtener información del animator: {e.Message}");
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
        if (isAttacking) yield break;
        
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
        if (isAttacking) yield break;
        
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
    
    // Este método se llama cuando los colliders de ataque tocan algo
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si es el jugador y si podemos hacer daño
        if (other.CompareTag("Player") && canDamagePlayer)
        {
            DamagePlayer(other.gameObject);
        }
    }
    
    private void DamagePlayer(GameObject player)
    {
        // Obtener el componente PlayerCombat del jugador tocado
        PlayerCombat combat = player.GetComponent<PlayerCombat>();
        
        if (combat != null)
        {
            Debug.Log($"Jefe atacó al jugador por {damageAmount} de daño");
            
            // Aplicar daño
            combat.RemoveLife(damageAmount);
            
            // Iniciar cooldown de daño
            StartCoroutine(DamageCooldown());
            
            // Verificar si el jugador murió
            CheckIfPlayerDied(combat);
        }
    }
    private void CheckIfPlayerDied(PlayerCombat combat)
    {
        // Verificar si el jugador se quedó sin vida
        if (combat.GetCurrentHealth() <= 0)
        {
            Debug.Log("¡El jugador ha muerto! Iniciando cambio de jugador...");
            
            // Notificar al GameManager sobre la muerte del jugador
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.OnPlayerDeath(currentPlayer);
            }
            else
            {
                Debug.LogWarning("No se encontró GameManager. El cambio de jugador debe manejarse manualmente.");
                // Cambio manual como backup
                HandlePlayerDeathFallback();
            }
        }
    }
    
    private void HandlePlayerDeathFallback()
    {
        // Método de respaldo si no hay GameManager
        StartCoroutine(ChangePlayerAfterDeath());
    }
    
    private IEnumerator ChangePlayerAfterDeath()
    {
        // Esperar un momento para efectos visuales
        yield return new WaitForSeconds(1f);
        
        // Desactivar jugador actual
        if (currentPlayer != null)
        {
            currentPlayer.SetActive(false);
        }
        
        // Buscar el nuevo jugador (debe estar inactivo)
        GameObject newPlayer = GameObject.FindGameObjectWithTag("Player2");
        if (newPlayer != null)
        {
            newPlayer.SetActive(true);
            
            // Actualizar referencias
            currentPlayer = newPlayer;
            playerCombat = newPlayer.GetComponent<PlayerCombat>();
            
            Debug.Log("¡Nuevo jugador activado!");
        }
        else
        {
            Debug.LogError("No se encontró el jugador de respaldo con tag 'Player2'");
        }
    }
    
    IEnumerator DamageCooldown()
    {
        canDamagePlayer = false;
        yield return new WaitForSeconds(damageCD);
        canDamagePlayer = true;
    }
    
    public void StopAllAttacks()
    {
        StopAllCoroutines();
        rightAttack.enabled = false;
        leftAttack.enabled = false;
        rightAttack.size = Vector2.one;
        leftAttack.size = Vector2.one;
        isAttacking = false;
    }
    
    // Método para recibir daño (si el jefe también puede ser dañado)
    public void TakeDamage(int damage)
    {
        lifes -= damage;
        Debug.Log($"Jefe recibió {damage} de daño. Vida restante: {lifes}");
        
        if (lifes <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("¡El jefe ha sido derrotado!");
        StopAllAttacks();
        SceneManager.LoadScene(22);
    }
    
    // Método para actualizar referencias cuando cambie el jugador
    public void UpdatePlayerReferences(GameObject newPlayer)
    {
        damageAmount = 10;
        currentPlayer = newPlayer;
        playerCombat = newPlayer.GetComponent<PlayerCombat>();
        playerCombat.SetCurrentHealth(health);
        Debug.Log("Referencias del jefe actualizadas al nuevo jugador");
    }
}