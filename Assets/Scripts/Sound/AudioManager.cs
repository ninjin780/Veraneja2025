using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer audioMixer;
    public AudioSource audioSource;
    private Scene scene;
    private int sceneIndex;
    public static int currentScene;
    public static bool aaaaaa = true;
    private bool grito;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        currentScene = -1;
        grito = false;
    }

    public void Play(string name)
    {
        audioSource.clip = Array.Find(sounds, sound => sound.name == name).clip;
        audioSource.Play();
    }


    void FixedUpdate()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
        if (currentScene != sceneIndex)
        {
            if (sceneIndex == 4)
            {
                Debug.Log("1");
                if (!grito)
                {   
                    audioSource.loop = false;
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
               Play("Caves");
               Debug.Log("3");

            }
            else
            {
                Play("Musica");
                Debug.Log("2");
            }
            currentScene = sceneIndex;
        }
    }
}
