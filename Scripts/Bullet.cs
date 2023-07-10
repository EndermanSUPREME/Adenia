using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BulletRB;
    public float damage = 1;
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D playerRB2D;

    // Update is called once per frame
    void Start()
    {
        BulletRB.velocity = playerRB2D.velocity * 4;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= 15)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.GetComponent<EnemyHealth>() != null)
        {
            // AI Death
            collision2D.transform.GetComponent<EnemyHealth>().TakeDamage(damage);

        };

        Destroy(gameObject);
    }
}//EndScript