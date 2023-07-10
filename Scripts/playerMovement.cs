using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] Transform newCursor, MyMainCam, BulletSpawn;
    [SerializeField] GameObject bulletPrefab, newBullet;
    private Vector2 MousePosition;
    private Rigidbody2D Rigidbody2D;
    [Range(0.1f, 10f)] public float speed, ShootDelay;
    public float time;
    private float X, Y, angle;
    [SerializeField] private bool shooting;
    public AudioSource bulletSound, GameMusic;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        
        Rigidbody2D = transform.GetComponent<Rigidbody2D>();
        time = 1;

        SetTheScreen();
    }

    private void SetTheScreen()
    {
        int ScreenX = PlayerPrefs.GetInt("screenWidth");
        int ScreenY = PlayerPrefs.GetInt("screenHeight");

        Screen.SetResolution(ScreenX, ScreenY, true);
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;

        if (time > 0)
        {
            ConfigCursor();
            Movement();
            
            if (Input.GetButton("Fire1") == true && shooting == false)
            {
                Shoot();
            }
        } else
            {
                Rigidbody2D.velocity = Vector2.zero;
            }

        GameMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // sets the newCursor to the position of the mouse on screen
    private void ConfigCursor()
    {
        MyMainCam.position = new Vector3(transform.position.x, transform.position.y, MyMainCam.position.z);

        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newCursor.position = new Vector3(MousePosition.x, MousePosition.y, 0);
    }

    // moves the player in direction of cursor
    private void Movement()
    {
        Vector2 mousePos = Input.mousePosition;

        X = (Screen.width/2) - mousePos.x;
        Y = (Screen.height/2) - mousePos.y;

        angle = Mathf.Atan2(Y, X) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        bool LeftShift = Input.GetKey(KeyCode. LeftShift);
        if (LeftShift == true)
        {
            Rigidbody2D.velocity = transform.up * speed * 1.45f * time;
        } else
            {
                Rigidbody2D.velocity = transform.up * speed * time;
            }
    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(ShootDelay);

        newBullet = null;
        shooting = false;
    }

    // responsible for shooting
    private void Shoot()
    {
        if (newBullet != null)
        {
            if (newBullet.active == false)
            {   
                newBullet.SetActive(true);
                bulletSound.Play();
            } else
                {
                    StartCoroutine(FireDelay());
                    shooting = true;
                }
        } else
            {
                newBullet = Instantiate(bulletPrefab, BulletSpawn.position, transform.rotation);
            }
    }
}//EndScript