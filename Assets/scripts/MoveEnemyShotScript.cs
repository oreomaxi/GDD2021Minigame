using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyShotScript : MonoBehaviour
{
    public float speed = 5;
    public Vector3 direction;



    private void Start()
    {
        
        Vector3 PlayerPosition = GameObject.Find("Player").transform.position;

        direction = (PlayerPosition - transform.position).normalized;



    }
    void Update()
    {
        MoveShot();


    }



    void MoveShot()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.x += speed * direction.x * Time.deltaTime;
        currentPosition.y += speed * direction.y * Time.deltaTime;
        transform.position = currentPosition;

    }

    
}
