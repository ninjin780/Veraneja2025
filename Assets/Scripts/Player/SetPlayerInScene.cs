using UnityEngine;

public class SetPlayerInScene : MonoBehaviour
{
    public Transform playerTransform,transformDerecho,transformIzquierdo;
    void Start()
    {
        if (PlayerPrefs.GetInt("Lado Derecho") == 1)
        {
            playerTransform.position = transformDerecho.position;
        }
        else if(PlayerPrefs.GetInt("Lado Derecho") == 0)
        {
            playerTransform.position = transformIzquierdo.position;
        }
    }
}
