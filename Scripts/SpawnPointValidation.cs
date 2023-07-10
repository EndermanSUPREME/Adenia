using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointValidation : MonoBehaviour
{
    public Transform Player;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float distance, radius;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.position);

        if (distance < 10 || distance > 30)
        {
            spawnPoint.SetActive(false);
        } else
            {
                spawnPoint.SetActive(true);
            }
    }

    void OnDrawGizmosSelected()
    {
        if (spawnPoint.active)
        {
            Gizmos.DrawSphere(spawnPoint.transform.position, radius);
            Gizmos.color = Color.red;
        };
    }
}//EndScript