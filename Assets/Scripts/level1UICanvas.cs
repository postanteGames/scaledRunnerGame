using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1UICanvas : MonoBehaviour
{
    // Start is called before the first frame update
    Move move;
    public GameObject GOpowerUpButton;
    public Animator _animator;
    private void Start()
    {
        move = GameObject.Find("Karakter").GetComponent<Move>();
        _animator = GameObject.Find("Karakter").transform.GetComponentInChildren<Animator>().GetComponent<Animator>();
        GOpowerUpButton.SetActive(false);
    }
    public void Startbutton()
    {
        _animator.SetBool("Basladi", true);
        move.speed = 10f;
        move.oyunBasladi = true;
        GOpowerUpButton.SetActive(true);
    }
    public void powerUpButton()
    {        
        GOpowerUpButton.SetActive(false); //veya karakter hýzý baz alýnarak bir if koþulu ile
                                          //startcoroutine'in çalýþmasýný kontrol altýna albiliriz
                                          // örnek : if(move.speed<11 && move.speed<1)
                                          //            StartCoroutine(powerup());
        StartCoroutine(powerup());     
    }

    IEnumerator powerup()
    {        
        move.speed *= 2;
        yield return new WaitForSecondsRealtime(5f);
        move.speed /= 2;
        yield return new WaitForSecondsRealtime(5f);
        GOpowerUpButton?.SetActive(true);
    }
}
