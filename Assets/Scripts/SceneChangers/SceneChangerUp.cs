using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerUp : MonoBehaviour
{
    public void Interact1()
    {
        PlayerPrefs.SetInt("SpawnPosition",3);
        SceneManager.LoadScene(4);
    }
    public void Interact2()
    {
        PlayerPrefs.SetInt("SpawnPosition",1);
        SceneManager.LoadScene(6);
    }
    public void Interact3()
    {
        PlayerPrefs.SetInt("SpawnPosition",2);
        SceneManager.LoadScene(7);
    }
    public void Interact4()
    {
        PlayerPrefs.SetInt("SpawnPosition",3);
        SceneManager.LoadScene(9);
    }
    public void Interact5()
    {
        PlayerPrefs.SetInt("SpawnPosition",3);
        SceneManager.LoadScene(12);
    }
    public void Interact6()
    {
        PlayerPrefs.SetInt("SpawnPosition",3);
        SceneManager.LoadScene(15);
    }
    public void Interact7()
    {
        PlayerPrefs.SetInt("SpawnPosition",3);
        SceneManager.LoadScene(17);
    }
}
