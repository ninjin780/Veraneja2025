using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;
    public static bool IsPaused;

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
}
