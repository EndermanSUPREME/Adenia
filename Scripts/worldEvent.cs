using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldEvent : MonoBehaviour
{
    int seconds, spawnPointIndex;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject MetriodPrefab, bossShipPrefab, alienBossPrefab;
    GameObject spawnedBoss;

    void Start()
    {
        spawnedBoss = null;

        seconds = Random.Range(2,4);
        StartCoroutine(WorldEvent(seconds));

        MeteorStorm();
    }

    IEnumerator WorldEvent(int secs)
    {
        int minutes = secs * 60;
        int eventKey = Random.Range(0,2);

        yield return new WaitForSeconds(minutes);

        EventGenerator(eventKey);
    }

    void EventGenerator(int eventID)
    {
        seconds = Random.Range(2,5);

        switch (eventID)
        {
            case 0: // meteriod storm

                MeteorStorm();
            break;
            case 1: // boss ship

                BattleShip();
            break;
            case 2: // alien boss

                AlienAttack();
            break;
            default:
            break;
        }

        StartCoroutine(WorldEvent(seconds));
    } // end of Event Gen

//=======================================================================================//

    private void MeteorStorm()
    {
        if (spawnPoints != null)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(MetriodPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

    private void BattleShip()
    {
        if (spawnPoints != null && spawnedBoss == null && bossShipPrefab != null)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);

            while (!spawnPoints[spawnPointIndex].gameObject.active)
            {
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
            }

            if (spawnPoints[spawnPointIndex].gameObject.active)
            {
                spawnedBoss = Instantiate(bossShipPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            }
        }
    }

    private void AlienAttack()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);

        while (!spawnPoints[spawnPointIndex].gameObject.active)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
        }

        if (spawnPoints != null && spawnedBoss == null && alienBossPrefab != null)
        {
            if (spawnPoints[spawnPointIndex].gameObject.active)
            {
                spawnedBoss = Instantiate(alienBossPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
            }
        }
    }
}//EndScript