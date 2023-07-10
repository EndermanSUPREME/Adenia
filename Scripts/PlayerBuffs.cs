using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuffs : MonoBehaviour
{
    [SerializeField] Transform LevelManager, Player, bulletPrefab;
    [SerializeField] Text TxtOne, TxtTwo, TxtThree;
    private int TotalPoints;
    private bool Alpha1, Alpha2, Alpha3;
    private int CostOne, CostTwo, CostThree;
    public AudioSource powerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        CostOne = 150;
        CostTwo = 250;
        CostThree = 400;
    }

    // Update is called once per frame
    void Update()
    {
        TotalPoints = LevelManager.GetComponent<LevelManager>().GameScore;

        TxtOne.text = CostOne.ToString();
        TxtTwo.text = CostTwo.ToString();
        TxtThree.text = CostThree.ToString();

        Alpha1 = Input.GetKeyDown(KeyCode. Alpha1);
        Alpha2 = Input.GetKeyDown(KeyCode. Alpha2);
        Alpha3 = Input.GetKeyDown(KeyCode. Alpha3);

        if (Alpha1 && TotalPoints >= CostOne)
        {
            ShootSpeed();
        } else if (Alpha2 && TotalPoints >= CostTwo)
            {
                MovementSpeed();
            } else if (Alpha3 && TotalPoints >= CostThree)
                {
                    DamageIncrease();
                }
    }

    private void ShootSpeed()
    {
        powerUpSound.Play();
        Player.GetComponent<playerMovement>().ShootDelay -= 0.05f;
        LevelManager.GetComponent<LevelManager>().Score(-CostOne);
        CostOne += 150;
    }

    private void MovementSpeed()
    {
        powerUpSound.Play();
        Player.GetComponent<playerMovement>().speed += 0.25f;
        LevelManager.GetComponent<LevelManager>().Score(-CostTwo);
        CostTwo += 300;
    }

    private void DamageIncrease()
    {
        powerUpSound.Play();
        bulletPrefab.GetComponent<Bullet>().damage += 2;
        LevelManager.GetComponent<LevelManager>().Score(-CostThree);
        CostThree += 600;
    }
    
}//EndScript