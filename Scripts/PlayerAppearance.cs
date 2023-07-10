using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAppearance : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] int index = 0;
    [SerializeField] Sprite[] playerSprites;
    [SerializeField] Image display;
    [SerializeField] Animator anim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        PlayerPrefs.GetInt("Appearence");
        
        playerSpriteChange();
    }

    void playerSpriteChange()
    {
        spriteRenderer.sprite = playerSprites[index];
        display.sprite = playerSprites[index];
        PlayerPrefs.SetInt("Appearence", index);
    }

    public void Next()
    {
        if (index < playerSprites.Length - 1)
        {
            index++;
            playerSpriteChange();
        }
    }

    public void Previous()
    {
        if (index > 0)
        {
            index--;
            playerSpriteChange();
        }
    }

    public void OpenCustomizePage()
    {
        anim.Play("opening");
    }

    public void CloseCustomizePage()
    {
        anim.Play("closing");
    }

}//EndScript