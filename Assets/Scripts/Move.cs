using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed,hizDegiskeni,MaxX;
    Touch touch;
    public bool solMax, sagMax,oyunBasladi;   
    public void move()
    {
        transform.Translate(0, 0, 1 * Time.fixedDeltaTime * speed);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved && solMax != true && sagMax != true)
            {
                MaxX = Mathf.Clamp(transform.position.x, -2, 2);
                transform.position = new Vector3(MaxX + touch.deltaPosition.x * hizDegiskeni,
                                                 transform.position.y,
                                                 transform.position.z);
            }


        }
        if (transform.position.x > 2)
        {
            sagMax = true;
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
            solMax = false;
        }
        else if (transform.position.x < -2)
        {
            solMax = true;
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
            sagMax = false;
        }
        else
        {
            solMax = false;
            sagMax = false;
        }
    }
    void FixedUpdate()
    {
        if(oyunBasladi==true)
        move();
    }   
}
