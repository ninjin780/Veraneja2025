using UnityEngine;
using UnityEngine.SceneManagement;
public class HoleInteraction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    public void Interact1()
    {
        PlayerPrefs.SetInt("SpawnPosition",0);
        SceneManager.LoadScene(10);
    }
    public void Interact2()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(11);
    }
    public void Interact3()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(18);
    }
}
