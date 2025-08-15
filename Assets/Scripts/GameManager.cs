using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Jugadores")]
    public GameObject player1; // Jugador principal
    public GameObject player2; // Jugador de respaldo (con sprite diferente)
    
    [Header("Configuración")]
    public float deathAnimationTime = 1f;
    public float respawnDelay = 0.5f;
    
    private GameObject currentPlayer;
    private bool hasChangedPlayer = false;
    private AudioSource audioSource;
    
    // Referencias a otros sistemas
    private BossAttacks bossAttacks;
    
    void Start()
    {
        InitializeGameManager();
        SetupInitialPlayer();
    }
    
    private void InitializeGameManager()
    {
        // Obtener componente de audio si existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // Encontrar referencias importantes
        bossAttacks = FindObjectOfType<BossAttacks>();
        
        // Validar que los jugadores estén asignados
        if (player1 == null || player2 == null)
        {
            Debug.LogError("[GameManager] ¡Debes asignar ambos jugadores en el Inspector!");
        }
    }
    
    private void SetupInitialPlayer()
    {
        // Configurar jugador inicial
        if (player1 != null)
        {
            player1.SetActive(true);
            currentPlayer = player1;
            
            // Asegurar que el jugador tenga el tag correcto
            if (!player1.CompareTag("Player"))
            {
                player1.tag = "Player";
            }
        }
        
        // Asegurar que el segundo jugador esté inactivo
        if (player2 != null)
        {
            player2.SetActive(false);
            
            // Configurar tag del segundo jugador
            if (!player2.CompareTag("Player2"))
            {
                player2.tag = "Player2";
            }
        }
    }
    
    public void OnPlayerDeath(GameObject deadPlayer)
    {
        Debug.Log($"GameManager: Jugador {deadPlayer.name} ha muerto");
        
        // Solo cambiar una vez
        if (hasChangedPlayer)
        {
            Debug.Log("Ya se cambió de jugador anteriormente. Game Over.");
            HandleGameOver();
            return;
        }
        
        StartCoroutine(HandlePlayerDeath(deadPlayer));
    }
    
    private IEnumerator HandlePlayerDeath(GameObject deadPlayer)
    {
        // Cambiar al segundo jugador
        yield return StartCoroutine(SwitchToSecondPlayer(deadPlayer));
    }
    
    private IEnumerator SwitchToSecondPlayer(GameObject deadPlayer)
    {
        Debug.Log("Cambiando al segundo jugador...");
        
        // Guardar posición del jugador muerto
        Vector3 spawnPosition = deadPlayer.transform.position;
        
        // Desactivar jugador muerto
        deadPlayer.SetActive(false);
        
        // Esperar un momento
        yield return new WaitForSeconds(respawnDelay);
        
        // Activar segundo jugador
        if (player2 != null)
        {
            // Posicionar el nuevo jugador
            player2.transform.position = spawnPosition;
            player2.SetActive(true);
            
            // Cambiar tag para que sea reconocido como jugador principal
            player2.tag = "Player";
            
            // Actualizar referencia actual
            currentPlayer = player2;
            hasChangedPlayer = true;
            
            // Notificar a otros sistemas
            NotifySystemsOfPlayerChange();
            
            Debug.Log("¡Segundo jugador activado exitosamente!");
        }
        else
        {
            Debug.LogError("No hay segundo jugador disponible!");
            HandleGameOver();
        }
    }
    
    private void NotifySystemsOfPlayerChange()
    {
        // Actualizar referencias del jefe
        if (bossAttacks != null)
        {
            bossAttacks.UpdatePlayerReferences(currentPlayer);
        }
        
        // Actualizar otros sistemas que necesiten la referencia del jugador
        UpdateAllPlayerReferences();
    }
    
    private void UpdateAllPlayerReferences()
    {
        // Buscar todos los scripts que necesiten actualizar la referencia del jugador
        DamagePlayer[] damageScripts = FindObjectsOfType<DamagePlayer>();
        foreach (DamagePlayer damage in damageScripts)
        {
            // Si tienes un método para actualizar referencias, llamarlo aquí
        }
        
        // Buscar NPCs y otros sistemas
        NPCsInteractions[] npcs = FindObjectsOfType<NPCsInteractions>();
        foreach (NPCsInteractions npc in npcs)
        {
            // Actualizar referencias si es necesario
        }
    }
    
    private void HandleGameOver()
    {
        Debug.Log("GAME OVER - Ambos jugadores han muerto");
        
        // Aquí puedes implementar la lógica de Game Over
        // Por ejemplo: mostrar pantalla de Game Over, reiniciar nivel, etc.
        
        StartCoroutine(GameOverSequence());
    }
    
    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(21);
        
        
        Debug.Log("Implementar lógica de Game Over aquí");
    }
}