using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public BoxCollider2D boxColliderLeft;
    public BoxCollider2D boxColliderRight;
    public BoxCollider2D playerCollider;
    public Transform playerTransform;
    
    void Update()
    {
        if (boxColliderRight.IsTouching(playerCollider))
        {
            PlayerPrefs.SetInt("Lado Derecho",0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else if (boxColliderLeft.IsTouching(playerCollider))
        {
            PlayerPrefs.SetInt("Lado Derecho",1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            //playerTransform.position = new Vector2(-playerTransform.position.x, playerTransform.position.y);
        }
    }
}
