using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Setup : MonoBehaviour
{
    public Text artist;
    public Text title;
    public Text lvl;
    public Button thisButton;

    void Start()
    {
        
    }

    public void setup(int row, string[][] Data)
    {
        if (Data[row][27] == "0")
        {
            thisButton.interactable = false;
        }
        title.text = Data[row][1];
        artist.text = Data[row][2];

        switch (Data[row][7])
        {
            case "1":
                var ezclear = transform.Find("ezclear").gameObject;
                ezclear.SetActive(true);
                break;
            case "2":
                var ezfc = transform.Find("ezfc").gameObject;
                ezfc.SetActive(true);
                break;
            case "3":
                var ezap = transform.Find("ezap").gameObject;
                ezap.SetActive(true);
                break;
            default:
                break;
        }
        switch (Data[row][8])
        {
            case "1":
                var nlclear = transform.Find("nlclear").gameObject;
                nlclear.SetActive(true);
                break;
            case "2":
                var nlfc = transform.Find("nlfc").gameObject;
                nlfc.SetActive(true);
                break;
            case "3":
                var nlap = transform.Find("nlap").gameObject;
                nlap.SetActive(true);
                break;
            default:
                break;
        }
        switch (Data[row][9])
        {
            case "1":
                var hdclear = transform.Find("hdclear").gameObject;
                hdclear.SetActive(true);
                break;
            case "2":
                var hdfc = transform.Find("hdfc").gameObject;
                hdfc.SetActive(true);
                break;
            case "3":
                var hdap = transform.Find("hdap").gameObject;
                hdap.SetActive(true);
                break;
            default:
                break;
        }
        switch (Data[row][10])
        {
            case "1":
                var exclear = transform.Find("exclear").gameObject;
                exclear.SetActive(true);
                break;
            case "2":
                var exfc = transform.Find("exfc").gameObject;
                exfc.SetActive(true);
                break;
            case "3":
                var exap = transform.Find("exap").gameObject;
                exap.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void lvlset(int row, string[][] Data) 
    {
        switch (PlayerPrefs.GetString("difficulty"))
        {
            case "easy":
                lvl.text = "LVL " + Data[row][3];
                break;
            case "normal":
                lvl.text = "LVL " + Data[row][4];
                break;
            case "hard":
                lvl.text = "LVL " + Data[row][5];
                break;
            case "expert":
                lvl.text = "LVL " + Data[row][6];
                break;
        }
    }

    public void clicked()
    {
        Image albumArt = GameObject.FindGameObjectWithTag("Image").GetComponent<Image>();
        Text hiScore = GameObject.FindGameObjectWithTag("hiscore").GetComponent<Text>();
        Text hiAcc = GameObject.FindGameObjectWithTag("hiacc").GetComponent<Text>();
        Text hiCombo = GameObject.FindGameObjectWithTag("hicombo").GetComponent<Text>();
        PlayerPrefs.SetString("selectedSong", this.gameObject.tag);
        var album = Resources.Load<Sprite>("Album Art/" + this.gameObject.tag);
        albumArt.sprite = album;
        switch (PlayerPrefs.GetString("difficulty"))
        {
            case "easy":
                hiScore.text = "HIGH SCORE: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 11);
                hiAcc.text = "ACC: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 13) + "%";
                hiCombo.text = "COMBO: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 12);
                break;
            case "normal":
                hiScore.text = "HIGH SCORE: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 15);
                hiAcc.text = "ACC: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 17) + "%";
                hiCombo.text = "COMBO: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 16);
                break;
            case "hard":
                hiScore.text = "HIGH SCORE: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 19);
                hiAcc.text = "ACC: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 21) + "%";
                hiCombo.text = "COMBO: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 20);
                break;
            case "expert":
                hiScore.text = "HIGH SCORE: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 23);
                hiAcc.text = "ACC: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 25) + "%";
                hiCombo.text = "COMBO: " + LevelManager.instance.Lookup(int.Parse(this.gameObject.tag), 24);
                break;
        }
        
    }
}
