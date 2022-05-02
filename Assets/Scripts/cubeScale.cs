using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScale : MonoBehaviour
{
    Vector3 Temo;   
    public bool maxScalee, minScalee;
    public Move move;
    public Animator _animator;

    public void Cube(float deger,string type)
    {
        if (transform.localScale.y > 8.0)
        {           
            maxScalee = true;
            Temo.y = 10;
            transform.localScale = Temo;
        }
        else if (maxScalee==true&& transform.localScale.y<11.8)
        {
            maxScalee = false;
            Temo.y = 10;
            transform.localScale= Temo;
        }
        if (transform.localScale.y < 0.1)
            minScalee = true;
        else minScalee = false;

        if (maxScalee == false&& type == "arti")
        {
            Temo = transform.localScale;
            Temo.y = Temo.y * deger;
            transform.localScale = Temo;

        }
        if (minScalee == false&& type == "eksi")
        {
          
            Temo = transform.localScale;
            Temo.y = Temo.y * (deger / 4);
            transform.localScale = Temo;
        }
        if(transform.localScale.y < 0.1f)
        {
            _animator = transform.parent.transform.GetComponentInChildren<Animator>();
            move = transform.parent.GetComponent<Move>();
            _animator.SetBool("Dead", true);
            move.oyunBasladi = false;
            move.speed = 0;
            GameManager.Instance.reTry();
        }
    }
}
