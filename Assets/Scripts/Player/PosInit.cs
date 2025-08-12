using UnityEngine;

public class PosInit : MonoBehaviour
{
    public Transform player, spawnInicio;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Inicio") == 0)
        {
            player.position = spawnInicio.position;
        }
        PlayerPrefs.SetInt("Inicio", 1);
    }
}
