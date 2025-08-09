using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinuarPartida()
    {
        
    }

    public void Opciones()
    {
        SceneManager.LoadScene(3);
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
