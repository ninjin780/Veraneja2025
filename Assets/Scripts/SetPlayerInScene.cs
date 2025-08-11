using UnityEngine;

public class SetPlayerInScene : MonoBehaviour
{
    public Transform playerTransform,transformDerecho,transformIzquierdo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("Lado Derecho") == 1)
        {
            playerTransform.position = transformDerecho.position;
        }
        else
        {
            playerTransform.position = transformIzquierdo.position;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
