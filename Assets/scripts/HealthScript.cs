using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int healthPoints = 1;
    public bool isEnemy = true;
    public Transform explodeTransform;
    public bool isPlayer = false;
    public GameObject HealthText;
    public static int score = 0;
    public GameObject ScoreText;

    private void Start()
    {
        HealthText = GameObject.FindGameObjectWithTag("HealthText");
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText");

        if (isPlayer)
        {
            HealthText.GetComponent<TextMeshProUGUI>().text = "Health:" + healthPoints;
            ScoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
        }
    }
    private void Update()
    {
        if (isPlayer)
        {
            HealthText.GetComponent<TextMeshProUGUI>().text = "Health:" + healthPoints;
        }
    }
    public void Damage(int damageCount)
    {
        healthPoints -= damageCount;

        
        if (isEnemy)
        {
            score = score + 1;
            ScoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
        }

        if (healthPoints <= 0)
        {
            if (isPlayer)
            {
                SceneManager.LoadScene("EndScreen");
            }

            else
            {
                Destroy(gameObject);
                var explodeSound = Instantiate(explodeTransform) as Transform;
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShotScript shot = collision.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
    }

}
