using UnityEngine;
using Unity.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MenuOpciones : MonoBehaviour

{ 
    public Slider volumeSlider;
    public void Fullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeVolume(float v)
    {
        AudioManager.volume = v; 

    }
    void Start()
    {
        volumeSlider.value = AudioManager.volume;
    }
}
