using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Interact1()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(9);
    }
    public void Interact2()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(13);
    }

    public void Interact3()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(16);
    }
    public void Interact4()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(20);
    }
}
