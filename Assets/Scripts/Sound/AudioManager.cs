using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioSource audioSource;
    private Scene scene;
    private int sceneIndex;
    public static int currentScene = -1;
    public static bool aaaaaa = true;
    public static float volume = 1f;
    private bool grito;

    void Awake()
    {
        if (currentScene != -1)
        {
            Destroy(this);
            return;
        }else
        {
            DontDestroyOnLoad(gameObject);
            grito = false;
        }
            
    }

    public void Play(string name)
    {
        audioSource.clip = Array.Find(sounds, sound => sound.name == name).clip;
        audioSource.Play();
    }


    void FixedUpdate()
    {
        audioSource.volume = volume;
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
        if (currentScene != sceneIndex)
        {
            if (sceneIndex == 4)
            {
                if (!grito)
                {   
                    audioSource.loop = false;
                    audioSource.pitch = 1.5f;
                    Play("Grito");
                    grito = true;
                }
                else               
                {
                    Play("Iglesia");
                    audioSource.loop = true;

                }
            }
            else if (sceneIndex == 19)
            {   
                Play("Jefe1");

            }
            else if (sceneIndex == 7 || sceneIndex == 8 || sceneIndex == 10 || sceneIndex == 11 || sceneIndex == 18)
            {
                if (currentScene != 7 && currentScene != 8 && currentScene != 10 && currentScene != 11 && currentScene != 18)
                {
                    Play("Caves");
                }               
            }
            else
            {
                if (currentScene == 4 || currentScene == 19 || currentScene == 7 || currentScene == 8 || currentScene == 10 || currentScene == 11 || currentScene == 18 || currentScene == -1) { 
                    Play("Musica");
                    currentScene = sceneIndex;
                }
            }
            Debug.Log(currentScene);
            currentScene = sceneIndex;
        }
    }
}
