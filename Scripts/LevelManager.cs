using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int Level = 1, maxEnemiesInScene = 120, spawnPointIndex;
    public int numberOfEnemies = 0, GameScore;
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Text ScoreText;
    [SerializeField] Transform Parent;
    bool reloadEnemies = true;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = GameScore.ToString();
        AdjustEnemiesToSpawn();
        StartCoroutine(TotalEnemies());
    }

    void AdjustEnemiesToSpawn()
    {
        numberOfEnemies = (5 * Level);
        enemies = new GameObject[numberOfEnemies];

        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        int i = 0;

        yield return new WaitForSeconds(0.5f);

        if (numberOfEnemies < maxEnemiesInScene)
        {
            while (i < enemies.Length)
            {
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
    
                if (spawnPoints[spawnPointIndex].gameObject.active)
                {
                    enemies[i] = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                    i++;
                } else
                    {
                        spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    };
            };
        } else
            {
                while (i < maxEnemiesInScene)
                {
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
        
                    if (spawnPoints[spawnPointIndex].gameObject.active)
                    {
                        enemies[i] = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                        i++;
                    } else
                        {
                            spawnPointIndex = Random.Range(0, spawnPoints.Length);
                        };
                };
            };

        reloadEnemies = false;
    }

    IEnumerator TotalEnemies()
    {
        numberOfEnemies = enemies.Length;

        yield return new WaitForSeconds(0.85f);

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                numberOfEnemies--;
            }
        };

        if (numberOfEnemies <= 0)
        {
            Level++;
            AdjustEnemiesToSpawn();
        };

        StartCoroutine(TotalEnemies());
    }

    public void Score(int amount)
    {
        GameScore += amount;
        ScoreText.text = GameScore.ToString();
    }

    public int GetCurrentLevel()
    {
        return Level;
    }

    public Transform[] GetSpawnPoints()
    {
        return spawnPoints;
    }

}//EndScript