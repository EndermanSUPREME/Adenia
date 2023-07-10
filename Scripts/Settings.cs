using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public int[] ScreenWidth, ScreenHeight;
    public float musicVolume;
    public Animator animator;
    public Slider MusicSlider, SetRes;
    private int screenSetNum, SFX_Int;
    public Text ResVisual;
    public GameObject h2pScreen;
    public AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("NewSettings") == 0)
        {
            DefaultSettings();
        } else
            {
                GetSaveData();
            }

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void DefaultSettings()
    {
        MusicSlider.value = 1f;
        musicVolume = 0.1f;
        LowSFX();

        SetRes.value = 9;
        ResVisual.text = (ScreenWidth[9].ToString() + "X" + ScreenHeight[9].ToString());

        Screen.SetResolution(ScreenWidth[9], ScreenHeight[9], true);
    }

    // Update is called once per frame
    void Update()
    {
        ScreenSettings();
        AudioSettings();
    }

    public void OpenSettings()
    {
        animator.Play("opening");
    }

    private void ScreenSettings()
    {
        switch (SetRes.value)
            {
                case 0:
                    screenSetNum = 0;
                break;
                case 1:
                    screenSetNum = 1;
                break;
                case 2:
                    screenSetNum = 2;
                break;
                case 3:
                    screenSetNum = 3;
                break;
                case 4:
                    screenSetNum = 4;
                break;
                case 5:
                    screenSetNum = 5;
                break;
                case 6:
                    screenSetNum = 6;
                break;
                case 7:
                    screenSetNum = 7;
                break;
                case 8:
                    screenSetNum = 8;
                break;
                case 9:
                    screenSetNum = 9;
                break;
                case 10:
                    screenSetNum = 10;
                break;
                default:
                break;
            }

            ResVisual.text = (ScreenWidth[screenSetNum].ToString() + "X" + ScreenHeight[screenSetNum].ToString());

            SaveData();
    }

    private void AudioSettings()
    {
        bgMusic.volume = musicVolume;

        switch (MusicSlider.value)
            {
                case 0:
                    musicVolume = 0;
                break;
                case 1:
                    musicVolume = 0.1f;
                break;
                case 2:
                    musicVolume = 0.2f;
                break;
                case 3:
                    musicVolume = 0.3f;
                break;
                case 4:
                    musicVolume = 0.4f;
                break;
                case 5:
                    musicVolume = 0.5f;
                break;
                case 6:
                    musicVolume = 0.6f;
                break;
                case 7:
                    musicVolume = 0.7f;
                break;
                case 8:
                    musicVolume = 0.8f;
                break;
                case 9:
                    musicVolume = 0.9f;
                break;
                case 10:
                    musicVolume = 1;
                break;
                default:
                break;
            }
    }

    private void GetSaveData()
    {
        SetRes.value = (float) PlayerPrefs.GetInt("resSet");
        ResVisual.text = (ScreenWidth[screenSetNum].ToString() + "X" + ScreenHeight[screenSetNum].ToString());
        
        bgMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume") * 10;

        Screen.SetResolution(PlayerPrefs.GetInt("screenWidth"), PlayerPrefs.GetInt("screenHeight"), true);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("resSet", screenSetNum);
        PlayerPrefs.SetInt("screenWidth", ScreenWidth[screenSetNum]);
        PlayerPrefs.SetInt("screenHeight", ScreenHeight[screenSetNum]);
        
        PlayerPrefs.SetFloat("SFX_Set", SFX_Int);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        Screen.SetResolution(ScreenWidth[screenSetNum], ScreenHeight[screenSetNum], true);

        PlayerPrefs.SetInt("NewSettings", 1);
    }

    public void closeSettings()
    {
        SaveData();
        animator.Play("closing");
    }

    public void LowSFX()
    {
        SFX_Int = 1;
    }

    public void MedSFX()
    {
        SFX_Int = 2;
    }

    public void HighSFX()
    {
        SFX_Int = 3;
    }

    public void h2p()
    {
        animator.Play("closing");
        h2pScreen.SetActive(true);
    }

    public void BackButton()
    {
        animator.Play("opening");
        h2pScreen.SetActive(false);
    }

}//EndScript