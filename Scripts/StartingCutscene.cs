using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingCutscene : MonoBehaviour
{
    public Transform[] ships;
    public float speedOfShips, speedOfPlayer;
    public Transform DialogScript, player;
    public Animator enemyShip1, enemyShip2;

    IEnumerator GoToGame()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;

        player.transform.position = new Vector2(player.transform.position.x + speedOfPlayer, player.transform.position.y);

        foreach (var ship in ships)
        {
            ship.transform.position = new Vector2(ship.transform.position.x + speedOfShips, ship.transform.position.y);
        }

        if (DialogScript.GetComponent<DialogScript>().UsedIndex == 4)
        {
            enemyShip1.Play("Incoming");
            enemyShip2.Play("Incoming2");
        }
        if (DialogScript.GetComponent<DialogScript>().UsedIndex == 6)
        {
            enemyShip1.Play("backOff");
            enemyShip2.Play("backOff2");

            speedOfShips += 0.00055f;
            StartCoroutine(GoToGame());
        }
    }

    public void SkipDialogue()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitProgram()
    {
        Application.Quit();
    }
}//EndScript