using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteriodScript : MonoBehaviour
{
    Rigidbody2D rb2D;
    int Setscale;
    [SerializeField] Vector2 vel;
    bool move = false;
    float DirX, DirY, speed;
    GameObject Player;
    AudioSource explosionSound;
    [SerializeField] GameObject ParticleSystem;

    void Start()
    {
        move = false;
        ParticleSystem.SetActive(false);
        
        rb2D = GetComponent<Rigidbody2D>();
        Setscale = Random.Range(1, 4);

        transform.localScale = new Vector3(Setscale, Setscale, 1);

        Player = GameObject.Find("Player");
        explosionSound = GameObject.Find("MeteriodExplosionSound").GetComponent<AudioSource>();

        DirX = Player.transform.position.x - transform.position.x;
        DirY = Player.transform.position.y - transform.position.y;
        
        GetDir(DirX, DirY);

        transform.SetParent(GameObject.Find("SceneObjects").transform);

        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }

    void GetDir(float dirX, float dirY)
    {
        while (dirX % 2 == 0 && dirY % 2 == 0)
        {
            dirX = dirX / 2;
            dirY = dirY / 2;
        }

        vel.x = (dirX + Random.Range(-4, 4));
        vel.y = (dirY + Random.Range(-4, 4));

        speed = Random.Range(10, 15);

        move = true;
    }

    void FixedUpdate()
    {
        if (move)
        {
            vel = new Vector2(DirX / speed, DirY / speed);
            rb2D.velocity = vel;
        } else
            {
                rb2D.velocity = Vector2.zero;
            }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        move = false;
        transform.GetComponent<Collider2D>().enabled = false;
        transform.GetComponent<SpriteRenderer>().enabled = false;

        explosionSound.Play();

        if (collision2D.transform.GetComponent<EnemyHealth>() != null)
        {
            // AI Death
            collision2D.transform.GetComponent<EnemyHealth>().TakeDamage(10000);
        };

        if (collision2D.transform == Player.transform)
        {
            Player.GetComponent<PauseScript>().gameOver();
        }

        ParticleSystem.SetActive(true);
    }

    public void PauseMeteriod()
    {
        move = false;
    }

    public void UnPauseMeteriod()
    {
        move = true;
    }

}//EndScript