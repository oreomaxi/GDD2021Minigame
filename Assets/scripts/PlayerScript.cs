using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed = 5;
    private float maxY = 2.5f;
    private float maxX = 3.5f;
    private float minY = -2.5f;
    private float minX = -4;

    private AudioSource audiosource;
    private SpriteRenderer spriteRenderer;
    public Sprite greenSprite;
    private PlayerScript playerScript;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3(-3, 0, 0);
        transform.position = spawnPosition;
        audiosource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();

        if (StartGameScript.playerSelected == 1)
        {
            spriteRenderer.sprite = greenSprite;
            playerScript.speed = 2;
        }
        

      
    }
    void Update()
    {
        MovePlayer();
        AimToMouse();
        bool shoot = Input.GetButtonDown("Fire1");

        if (shoot)
        {
            PlayerShootScript PlayerShoot = GetComponent<PlayerShootScript>();
            if (PlayerShoot != null)
            {
                PlayerShoot.Attack(false);
                audiosource.Play();
            }
        }


    }

    void MovePlayer()
    {
        maxX = Camera.main.transform.position.x + 4;
        minX = Camera.main.transform.position.x - 5;
        if (Input.GetAxis("Vertical") > 0)
        {
            Vector2 currentPosition = transform.position;
            currentPosition.y += speed * Time.deltaTime;

            if (currentPosition.y > maxY)
            {
                currentPosition.y = maxY;
            }

            transform.position = currentPosition;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Vector2 currentposition = transform.position;
            currentposition.y -= speed * Time.deltaTime;

            if (currentposition.y < minY)
            {
                currentposition.y = minY;
            }

            transform.position = currentposition;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector2 currentPosition = transform.position;
            currentPosition.x += speed * Time.deltaTime;

            if (currentPosition.x > maxX)
            {
                currentPosition.x = maxX;
            }

            transform.position = currentPosition;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            Vector2 currentposition = transform.position;
            currentposition.x -= speed * Time.deltaTime;

            if (currentposition.x < minX)
            {
                currentposition.x = minX;
            }

            transform.position = currentposition;
        }


    }

    void AimToMouse()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 LookAtDirection = (MousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(LookAtDirection.y, LookAtDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.healthPoints);

            damagePlayer = true;
        }

        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
}
