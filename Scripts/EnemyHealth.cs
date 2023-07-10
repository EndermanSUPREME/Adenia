using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float TotalHealth;
    private int currentLevel, pointValue;
    [SerializeField] private Transform Player;
    private Rigidbody2D Rigidbody2D;
    public float speed;
    public float time = 1;
    [SerializeField] Slider enemyHealthSlider;
    LevelManager levelmanager;
    AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.Find("SceneObjects").transform);
        levelmanager = (LevelManager)FindObjectOfType(typeof(LevelManager));
        Player = GameObject.Find("Player").transform;
        deathSound = GameObject.Find("DeathSound").GetComponent<AudioSource>();

        currentLevel = levelmanager.GetCurrentLevel();
        
        if (transform.tag != "boss")
        {
            TotalHealth = Mathf.Pow(1.25f, currentLevel);

            if (currentLevel < 5)
            {
                pointValue = (int)Mathf.Round(15 * (currentLevel * 0.75f));
            }
        } else // is a boss
            {
                TotalHealth = (Mathf.Pow(1.25f, currentLevel)) * 3.15f;

                if (currentLevel < 5)
                {
                    pointValue = (int)Mathf.Round(150 * (currentLevel * 0.56f));
                }
            }
        
        enemyHealthSlider.maxValue = TotalHealth;
        enemyHealthSlider.value = TotalHealth;

        time = 1;
        Rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        levelmanager = (LevelManager)FindObjectOfType(typeof(LevelManager));
        Movement();
    }

    private void Movement()
    {
        Vector2 PlayerPos = Player.position;

        float X = transform.position.x - PlayerPos.x;
        float Y = transform.position.y - PlayerPos.y;

        float angle = Mathf.Atan2(Y, X) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        Rigidbody2D.velocity = transform.up * speed * time;
    }

    public void TakeDamage(float amount)
    {
        enemyHealthSlider.value = TotalHealth;
        TotalHealth -= amount;

        if (TotalHealth <= 0)
        {
            levelmanager.Score(pointValue);

            deathSound.Play();
            Destroy(gameObject);
        }
    }
}//EndScript