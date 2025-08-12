using UnityEngine;
using Unity.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;


public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void Fullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
