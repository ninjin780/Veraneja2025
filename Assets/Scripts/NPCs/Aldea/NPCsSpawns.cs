using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCsSpawns : MonoBehaviour
{
    public GameObject NPC;
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        switch (NPC.name)
        {
            case "Boo":
                if (PlayerPrefs.GetInt("Boo") == 1 && scene.name == "Right2")
                {
                    NPC.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Boo") != 1 && scene.name == "Right2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Boo") == 1 && scene.name == "Left2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Boo") != 1 && scene.name == "Left2")
                {
                    NPC.SetActive(true);
                }
                break;
            case "Milo":
                if (PlayerPrefs.GetInt("Milo") == 1 && scene.name == "Right2")
                {
                    NPC.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Milo") != 1 && scene.name == "Right2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Milo") == 1 && scene.name == "Left2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Milo") != 1 && scene.name == "Left2")
                {
                    NPC.SetActive(true);
                }
                break;
            case "Steve":
                if (PlayerPrefs.GetInt("Steve") != 1 && scene.name == "Mid")
                {
                    NPC.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Steve") == 1 && scene.name == "Mid")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Steve") != 1 && scene.name == "Left1")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Steve") == 1 && scene.name == "Left1")
                {
                    NPC.SetActive(true);
                }
                break;
            case "Virgil":
                if (PlayerPrefs.GetInt("Virgil") != 1 && scene.name == "Right2")
                {
                    NPC.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Virgil") == 1 && scene.name == "Right2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Virgil") != 1 && scene.name == "Left2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Virgil") == 1 && scene.name == "Left2")
                {
                    NPC.SetActive(true);
                }
                break;
            case "Ranastacio":
                if (PlayerPrefs.GetInt("Ranastacio") != 1 && scene.name == "Right2")
                {
                    NPC.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("Ranastacio") == 1 && scene.name == "Right2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Ranastacio") != 1 && scene.name == "Left2")
                {
                    NPC.SetActive(false);
                }
                else if (PlayerPrefs.GetInt("Ranastacio") == 1 && scene.name == "Left2")
                {
                    NPC.SetActive(true);
                }
                break;
        }
    }
}
