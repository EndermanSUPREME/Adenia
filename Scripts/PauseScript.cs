using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Animator anim;
    private bool paused = false, menusOpen = false;
    public Transform Host;
    [SerializeField] Transform[] ThisScene;
    private bool gameOverBool = false;

    // Update is called once per frame
    void Update()
    {
        ThisScene = Host.GetComponentsInChildren<Transform>();

        bool Escape = Input.GetKeyDown(KeyCode.Escape);
        if (Escape && !paused && !gameOverBool)
        {
            anim.Play("pullUp");
            menusOpen = true;
            StartCoroutine(Freeze());
        }

        if (Escape && paused == true && gameOverBool == false)
        {
            menusOpen = false;
            ResumeGame();
        }
    }

    IEnumerator Freeze()
    {
        foreach (Transform SceneObject in ThisScene)
        {
            if (SceneObject.transform.GetComponent<playerMovement>() != null)
            {
                SceneObject.transform.GetComponent<playerMovement>().time = 0;
            }

            if (SceneObject.transform.GetComponent<EnemyHealth>() != null)
            {
                SceneObject.transform.GetComponent<EnemyHealth>().time = 0;
            }

            if (SceneObject.transform.GetComponent<MeteriodScript>() != null)
            {
                SceneObject.transform.GetComponent<MeteriodScript>().PauseMeteriod();
            }
        }

        yield return new WaitForSeconds(0.1f);

        if (menusOpen)
        {
            StartCoroutine(Freeze());
        }
    }

    public void ResumeGame()
    {
        menusOpen = false;

        anim.Play("pullDown");
            foreach (var SceneObject in ThisScene)
            {
                if (SceneObject.transform.GetComponent<playerMovement>() != null)
                {
                    SceneObject.transform.GetComponent<playerMovement>().time = 1;
                }

                if (SceneObject.transform.GetComponent<EnemyHealth>() != null)
                {
                    SceneObject.transform.GetComponent<EnemyHealth>().time = 1;
                }

                if (SceneObject.transform.GetComponent<MeteriodScript>() != null)
                {
                    SceneObject.transform.GetComponent<MeteriodScript>().UnPauseMeteriod();
                }
            }

        paused = false;

        if (gameOverBool == true)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
        gameOverBool = true;
        anim.Play("pullUp");
            foreach (var SceneObject in ThisScene)
            {
                if (SceneObject.transform.GetComponent<playerMovement>() != null)
                {
                    SceneObject.transform.GetComponent<playerMovement>().time = 0;
                    SceneObject.transform.GetComponent<playerMovement>().enabled = false;
                }

                if (SceneObject.transform.GetComponent<EnemyHealth>() != null)
                {
                    SceneObject.transform.GetComponent<EnemyHealth>().time = 0;
                }
            }
    }
}//EndScript