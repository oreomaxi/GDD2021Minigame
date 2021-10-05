using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform shotPrefabRed;
    public Transform shotPrefabGreen;
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
        if(shootCooldown <= 0)
        {
            shootCooldown = shootingRate;
            
            if (StartGameScript.playerSelected == 0)
            {
                var shotTransform = Instantiate(shotPrefabRed) as Transform;
                shotTransform.position = transform.position;
                shotTransform.parent = gameObject.transform.parent;
                ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }

            }
            else
            {
                var shotTransform = Instantiate(shotPrefabGreen) as Transform;
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
}
