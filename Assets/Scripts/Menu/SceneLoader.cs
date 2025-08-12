using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void Jugar()
    {
        PlayerPrefs.SetInt("Inicio",0);
        SceneManager.LoadScene(4);
    }

    public void ContinuarPartida()
    {
        
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
