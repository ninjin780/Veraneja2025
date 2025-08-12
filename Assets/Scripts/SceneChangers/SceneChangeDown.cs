using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Interact1()
    {
        SceneManager.LoadScene(9);
    }
    public void Interact2()
    {
        SceneManager.LoadScene(13);
    }

    public void Interact3()
    {
        SceneManager.LoadScene(16);
    }
    public void Interact4()
    {
        SceneManager.LoadScene(18);
    }
    public void Interact5()
    {
        SceneManager.LoadScene(20);
    }
}
