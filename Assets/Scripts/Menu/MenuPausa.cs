using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;
    public static bool IsPaused = false;


    void Start()
    {
        menuPausa.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        SceneManager.LoadScene(0);
        Debug.Log("Load Main Menu");
    }
}
