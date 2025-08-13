using UnityEngine;

public class SetPlayerInScene : MonoBehaviour
{
    public Transform playerTransform, transformDerecho, transformIzquierdo, transformAbajo, transformMedio;

    void Start()
    {
        switch (PlayerPrefs.GetInt("SpawnPosition"))
        {
            case 0:
                playerTransform.position = transformIzquierdo.position;
                break;
            case 1:
                playerTransform.position = transformDerecho.position;
                break;
            case 2:
                playerTransform.position = transformMedio.position;
                break;
            case 3:
                playerTransform.position = transformAbajo.position;
                break;
            default:
                playerTransform.position = transformMedio.position;
                break;
        }
        PlayerPrefs.DeleteAll();
    }
}
