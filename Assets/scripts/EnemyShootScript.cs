using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    private float shootCooldown;

    private void Start()
    {
        shootCooldown = 0f;
    }

    private void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        if (shootCooldown <= 0)
        {
            shootCooldown = shootingRate;
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            shotTransform.parent = gameObject.transform.parent;
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }


        }
    }
}
