using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public BoxCollider2D boxColliderLeft;
    public BoxCollider2D boxColliderRight;
    public BoxCollider2D playerCollider;
    
    void Update()
    {
        if (boxColliderRight.IsTouching(playerCollider))
        {
            PlayerPrefs.SetInt("SpawnPosition",0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else if (boxColliderLeft.IsTouching(playerCollider))
        {
            PlayerPrefs.SetInt("SpawnPosition",1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }
}
