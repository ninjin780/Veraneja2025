using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsReproductions : MonoBehaviour
{
    private AudioManager audioManager;
    private Scene scene;
    private int sceneIndex;
    private bool IsActive = false;
    private bool grito = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
        if (sceneIndex == 4)
        {
            if (!grito)
            {
            StartCoroutine(Grito());
            }
            audioManager.Play("Iglesia");
        }
        else if (sceneIndex == 19)
        {
            audioManager.Play("Jefe1");
        }
        else if (sceneIndex == 7 || sceneIndex == 8 || sceneIndex == 10 || sceneIndex == 11 || sceneIndex == 18)
        {
            audioManager.Play("Caves");
        }
        else
        {
            audioManager.Play("Musica");
        }
    }

    IEnumerator Grito()
    {
        grito = true;
        audioManager.Play("Grito");
        yield return new WaitForSeconds(3f);
    }
}
