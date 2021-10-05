using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            Vector3 SpawnPoint = new Vector3(Camera.main.transform.position.x + 7, Random.Range(3.0f, 3.0f), 0);
            var Enemy = Instantiate(EnemyPrefab) as Transform;
            Enemy.position = SpawnPoint;
        }
    }
}
