using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    
  
    public int level;
    public float levelIciPuan;
   

    [Header("Levellarýn içi")]
    public TextMeshProUGUI Llevel;
   
    public TextMeshProUGUI Lpuan;
    [Header("Toplamlar")]
    public TextMeshProUGUI Gpara;
    

    [Header("GameManager'ýn içi")]
    public Text GmLevel;
    public Text GmPara;
    public Text GmPuan;
    public Text GmOncekiLevelParasi;
    public Text GmBulevelPara;





    //  public carpismaHabercisi carpismaHabercisi;
    void Awake()
    {

        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        level = PlayerPrefs.GetInt("Level");
        if (SceneManager.GetActiveScene().name == "mainMenu")
        {

        }

        else if (SceneManager.GetActiveScene().name != "mainMenu")
        {
            levelIciPuan = 1f;
            Debug.Log("mainmenuDeðil");
            GameObject go = GameObject.Find("Canvas");
            Lpuan = go.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Lpuan.text = levelIciPuan.ToString("F2");

            Gpara = go.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Gpara.text = PlayerPrefs.GetFloat("toplamPara").ToString("F2");

            Llevel = go.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            Llevel.text = "Level " + (SceneManager.GetActiveScene().buildIndex);

        }

        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);


    }
    public void playerPrefsReset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("mainMenu");
    }
    public void bitis()
    {
        
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);//Bitiþ Paneli
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("Level"))
        {
            level++;
            PlayerPrefs.SetInt("Level", level);
        }
        GmOncekiLevelParasi.text = "Toplamdan Önceki PAra : " + PlayerPrefs.GetFloat("toplamPara").ToString("F2");
        Gpara.text = ((float.Parse(Lpuan.text) * 10)+PlayerPrefs.GetFloat("toplamPara")).ToString("F2");
        GmBulevelPara.text = "Bu Level Para : " + (float.Parse(Lpuan.text)*10).ToString("F2");
        PlayerPrefs.SetFloat("toplamPara", float.Parse(Gpara.text));
        Gpara.text = PlayerPrefs.GetFloat("toplamPara").ToString("F2");
       
        GmLevel.text = "Level : " + SceneManager.GetActiveScene().buildIndex;
        GmPara.text ="Toplam Para : "+ PlayerPrefs.GetFloat("toplamPara").ToString("F2");
        GmPuan.text = "Puan : " + Lpuan.text;
      
    }
    public void leveliciPuan()
    {
        if (levelIciPuan == 1)
        {
            Lpuan.text = levelIciPuan.ToString("F2");
        }
        else if (levelIciPuan > 0.1)
            Lpuan.text = levelIciPuan.ToString("F2");
        else
            Lpuan.text = "0";

    }
    public void continueButton()
    {
        SceneManager.LoadScene("mainMenu");

        //SceneManager.LoadScene("Level"+(SceneManager.GetActiveScene().buildIndex+1)); eðer bu aktif olursa oyun içinde bir sonraki seviyeye geçer
    }
    public void reTry()
    {

        transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);//reTry Paneli
       
    }
    public void reTryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    
    
}
