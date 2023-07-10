using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Settings : MonoBehaviour
{
    public AudioSource[] sfxSounds;
    public AudioSource Bullet, Death, Power;

    private float vol1, vol2, vol3, setVolume;

    // Update is called once per frame
    void Update()
    {
        switch (PlayerPrefs.GetFloat("SFX_Set"))
        {
            case 3:
                vol1 = 0.596f;
                vol2 = 0.377f;
                vol3 = 0.714f;
                setVolume = 1;
            break;
            case 2:
                vol1 = 0.596f/2;
                vol2 = 0.377f/2;
                vol3 = 0.714f/2;
                setVolume = 0.5f;
            break;
            case 1:
                vol1 = 0.596f/3;
                vol2 = 0.377f/3;
                vol3 = 0.714f/3;
                setVolume = 0.25f;
            break;
            default:
            break;
        }

        // needed to be hard coded
        Bullet.volume = vol1;
        Death.volume = vol2;
        Power.volume = vol3;

        foreach (AudioSource Sound in sfxSounds)
        {
            Sound.volume = setVolume;
        }
    }
}//EndScript