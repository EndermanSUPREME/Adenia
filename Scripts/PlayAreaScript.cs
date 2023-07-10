using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaScript : MonoBehaviour
{
    [SerializeField] GameObject WarningAbove, WarningBelow, WarningLeft, WarningRight;
    [SerializeField] Transform TopBorder, BottomBorder, LeftBorder, RightBorder;
    [SerializeField] private float X, Y;
    public string tagName;

    // Update is called once per frame
    void Update()
    {
        WarningCheck();
    }

    private void WarningCheck()
    {
        if (transform.position.x >= X)
        {
            WarningRight.SetActive(true);
        } else
            {
                WarningRight.SetActive(false);
            }
            if (transform.position.x <= -X)
            {
                WarningLeft.SetActive(true);
            } else
                {
                    WarningLeft.SetActive(false);
                }
                if (transform.position.y >= Y)
                {
                    WarningAbove.SetActive(true);
                } else
                    {
                        WarningAbove.SetActive(false);
                    }
                    if (transform.position.y <= -Y)
                    {
                        WarningBelow.SetActive(true);
                    } else
                        {
                            WarningBelow.SetActive(false);
                        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.tag == tagName || collision2D.transform.tag == "Enemy")
        {
            // GameOver
            transform.GetComponent<PauseScript>().gameOver();
        }
    }
}//EndScript