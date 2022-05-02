using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carpismaHabercisi : MonoBehaviour
{
    public cubeScale cubeScale;
    public Move move;
    public Animator _animator;
    public ParticleSystem Pparcalanma,PtoplamaYukari,PtoplamaAsagi;   
    private void Start()
    {
        cubeScale       = transform.GetComponentInChildren<cubeScale>();
        move            = GetComponent<Move>();
        _animator       = transform.GetComponentInChildren<Animator>();
        Pparcalanma     = transform.GetChild(0).transform.GetChild(3).GetComponent<ParticleSystem>();
        PtoplamaYukari  = transform.GetChild(0).transform.GetChild(4).GetComponent<ParticleSystem>();
        PtoplamaAsagi   = transform.GetChild(0).transform.GetChild(5).GetComponent<ParticleSystem>();  
    }
    public void OnTriggerEnter(Collider other)
    {
        {
            var karakter = gameObject.transform.GetChild(0).transform.position;
            if (other.gameObject.tag.Equals("eksiYirmiBes"))
            {
                puan(3, "eksi");
                cubeScale.Cube(3,"eksi");
                Pparcalanma.Play();
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag.Equals("eksiElli"))
            {
                puan(2, "eksi");
                cubeScale.Cube(2,"eksi");
                Pparcalanma.Play();
                Destroy(other.gameObject);

            }
            if (other.gameObject.tag.Equals("artiYirmiBes"))
            {
                cubeScale.Cube(1.25f,"arti");
                puan(1.25f,"arti");
                PtoplamaYukari.Play();
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag.Equals("bitis"))
            {
        
                if (cubeScale.transform.localScale.y < 2)
                    _animator.SetBool("Mutsuz", true);
                else
                    _animator.SetBool("Mutlu", true);
                move.oyunBasladi = false;
                move.speed = 0;
                GameManager.Instance.bitis();
            }
            if (other.gameObject.tag.Equals("dead"))
            {
                puan(0.001f, "eksi");
                cubeScale.Cube(0.001f, "eksi");
                Pparcalanma.Play();
           
            }
            if (other.gameObject.tag.Equals("SeksiElli"))
            {
                puan(2, "eksi");
                cubeScale.Cube(2, "eksi");
                Pparcalanma.Play();
                Destroy(other.gameObject.transform.parent.gameObject);

            }
            if (other.gameObject.tag.Equals("SartiYirmiBes"))
            {
                cubeScale.Cube(1.25f, "arti");
                puan(1.25f,"arti");
                PtoplamaYukari.Play();
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            karakter.y = cubeScale.transform.localScale.y + 0.5f;
            gameObject.transform.GetChild(0).transform.position = karakter;            
        }
    }
    public void puan(float deger,string deger2)
    {
        if (deger2 == "arti")
        {
            GameManager.Instance.levelIciPuan = GameManager.Instance.levelIciPuan * deger;
            GameManager.Instance.leveliciPuan();
        }
        if(deger2 == "eksi")
        {
            GameManager.Instance.levelIciPuan = GameManager.Instance.levelIciPuan * (deger/4);
            GameManager.Instance.leveliciPuan();
        }
    }   
}
