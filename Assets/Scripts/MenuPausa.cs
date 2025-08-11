using UnityEngine;

public class MenuPausa
{
    
    public GameObject menuPausa;

    void Start()
    {
        // Initialize the pause menu
        menuPausa = GameObject.Find("MenuPausa");
        if (menuPausa != null)
        {
            menuPausa.SetActive(false); // Hide the menu at the start
        }
    }
    void Update()
    {
        // Check for the pause key (e.g., Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (menuPausa != null)
        {
            bool isActive = menuPausa.activeSelf;
            menuPausa.SetActive(!isActive); // Toggle the menu visibility
            // Pause or resume the game
            if (isActive)
            {
                Time.timeScale = 1f; // Resume the game
            }
            else
            {
                Time.timeScale = 0f; // Pause the game
            }
        }
    }
}
