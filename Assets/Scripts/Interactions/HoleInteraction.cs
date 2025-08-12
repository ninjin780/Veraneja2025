using UnityEngine;
using UnityEngine.SceneManagement;
public class HoleInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public void Interact1()
    {
        SceneManager.LoadScene(10);
    }
    public void Interact2()
    {
        SceneManager.LoadScene(11);
    }
}
