using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private EnemyShootScript EnemyShoot;
    private Vector3 PlayerPosition;
    private Vector3 direction;
    public int speed = 2;
    private GameObject[] PlayerBullets;

    private float maxY = 0.5f;
    private float maxX = 1.0f;
    private float minY = -0.5f;
    private float minX = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Dodge", 1.0f, 2.0f);
    }

    private void Awake()
    {
        EnemyShoot = GetComponent<EnemyShootScript>();
    }

    void Update()
    {

        Vector3 currentPosition = transform.position;
        PlayerPosition = GameObject.Find("Player").transform.position;
        direction = (PlayerPosition - transform.position).normalized;
        currentPosition.x += speed * direction.x * Time.deltaTime;
        currentPosition.y += speed * direction.y * Time.deltaTime;
        transform.position = currentPosition;

       
        //AutoAttack
        if (EnemyShoot != null)
        {
            EnemyShoot.Attack(true);
        }
    }

    void Dodge()
    {
        if (Random.Range(0.0f, 1.0f) > 0.6f)
        {
            return;
        }
        maxX = Camera.main.transform.position.x + 2;
        minX = Camera.main.transform.position.x - 2;

        PlayerBullets = GameObject.FindGameObjectsWithTag("PlayerBullet");
        Debug.Log(PlayerBullets.Length);
        if (PlayerBullets.Length > 0)
        {
            float shortestDistance = 0;
            int shortestDistanceIndex = 0;
            for (int i = 0; i < PlayerBullets.Length; i++)
            {
                if (shortestDistance > Vector3.Distance(PlayerBullets[i].transform.position, transform.position))
                {
                    shortestDistance = Vector3.Distance(PlayerBullets[i].transform.position, transform.position);
                    shortestDistanceIndex = i;

                }
            }
            MoveShotScript PlayerBulletShot = PlayerBullets[shortestDistanceIndex].gameObject.GetComponent<MoveShotScript>();


            Vector3 dodgedPosition = transform.position - 0.5f * PlayerBulletShot.direction; // + 0.1f * (PlayerBullets[shortestDistanceIndex].transform.position - transform.position).normalized;
            if (dodgedPosition.x > maxX)
            {
                dodgedPosition.x = maxX;
            }
            if (dodgedPosition.x < minX)
            {
                dodgedPosition.x = minX;
            }
            if (dodgedPosition.y > maxY)
            {
                dodgedPosition.y = maxY;
            }
            if (dodgedPosition.y > minY)
            {
                dodgedPosition.y = minY;
            }
            transform.position = dodgedPosition;

        }


    }
}
