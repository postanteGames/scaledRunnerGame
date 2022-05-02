using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class mainMenuUI : MonoBehaviour
{
    public TextMeshProUGUI toplamPara;
    public TextMeshProUGUI Level,gecilenLevel;
    public Text LevelRun,bilgiText;
    public GameObject Level1, Level2,Level3,Level4;
    public GameObject RunButton,GcontinueButton;
    public enum EnumLevel {level1,level2};
    public EnumLevel enumLevel;
    private void Start()
    {        
        Debug.Log("" + PlayerPrefs.GetInt("Level"));
        if (PlayerPrefs.GetInt("Level") >=1)
        {
            GcontinueButton.SetActive(true);
          
            Level1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") >=2)
        {
            Level2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") >= 3)
        {
            Level3.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") >= 4)
        {
            Level4.SetActive(true);
        }

        toplamPara.text ="Toplam Para : "+ PlayerPrefs.GetFloat("toplamPara").ToString("F2");     
        gecilenLevel.text = "Ge�ilen Level : " + PlayerPrefs.GetInt("Level");
        Level.text = "Continue Level : " + (PlayerPrefs.GetInt("Level")+1);
    }

    public void runButton()
    {
        /* switch (enumLevel)     Bu �ekilde de yap�labilirdi
         {
             case EnumLevel.level1:
                 PlayerPrefs.SetInt("istekLevel", 1);
                 break;
             case EnumLevel.level2:
                 PlayerPrefs.SetInt("istekLevel", 2);
                 break;
             default:
                 PlayerPrefs.SetInt("istekLevel", 1);
                 break;
         }*/
               /* string lvl = RunButton.transform.GetComponentInChildren<Text>().text;*/
   
        if (RunButton.transform.GetComponentInChildren<Text>().text != null)
        {
            //  PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("istekLevel"));
        }
        else
        {
            SceneManager.LoadScene("Level0");
        }
       
    }
    public void Level1Button()
    {
        RunButton.transform.GetComponentInChildren<Text>().text = "Level 1 Run";
        PlayerPrefs.SetInt("istekLevel",0);
        bilgiText.text = "Level 1'i Se�tiniz";
        //  enumLevel = EnumLevel.level1;
    }
    public void Level2Button()
    {
        RunButton.transform.GetComponentInChildren<Text>().text = "Level 2 Run";
        PlayerPrefs.SetInt("istekLevel",1);
        bilgiText.text = "Level 2'i Se�tiniz";
        // enumLevel = EnumLevel.level2;

    }
    public void Level3Button()
    {
        RunButton.transform.GetComponentInChildren<Text>().text = "Level 3 Run";
        bilgiText.text = "Level 3'i Se�tiniz";
        PlayerPrefs.SetInt("istekLevel", 2);
    }
    public void Level4Button()
    {
        RunButton.transform.GetComponentInChildren<Text>().text = "Level 4 Run";
        bilgiText.text = "Level 4'i Se�tiniz";
        PlayerPrefs.SetInt("istekLevel", 3);
    }
    public void continueButton()
    {
        if ("Level" + PlayerPrefs.GetInt("Level") == "Level4")
            bilgiText.text="5. Level Yap�m A�amas�nda Anlay���n�z i�in Te�ekk�rler.";
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
    }
    


    
   
}
