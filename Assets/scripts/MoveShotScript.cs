using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShotScript : MonoBehaviour
{

    public float speed = 5;
    public Vector3 direction;



    private void Start()
    {
        AimToMouse();
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (MousePosition - transform.position).normalized;



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

    void AimToMouse()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 LookAtDirection = (MousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(LookAtDirection.y, LookAtDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
