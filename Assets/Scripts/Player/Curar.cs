using UnityEngine;

public class Curar : MonoBehaviour
{
    public PlayerCombat playerCombat;
    void Start()
    {
        playerCombat.SetCurrentHealth(100); // Set initial health to 100
    }

    
}
