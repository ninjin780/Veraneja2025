using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void Jugar()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("SpawnPosition",4);
        SceneManager.LoadScene(4);
    }
    public void Opciones()
    {
        SceneManager.LoadScene(1);
    }
    public void Volver()
    {
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
