using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Setup : MonoBehaviour
{
    public Song song;
    public Text artist;
    public Text title;
    public Text lvl;
    public Button thisButton;
    public Button EZ, NL, HD, EX;

    void Start()
    {
        EZ.onClick.AddListener(lvls);
        NL.onClick.AddListener(lvls);
        HD.onClick.AddListener(lvls);
        EX.onClick.AddListener(lvls);
        title.text = song.title;
        artist.text = song.artist;
        if (song.isLocked)
        {
            thisButton.interactable = false;
        }
        switch (song.EZStatus)
        {
            case 1:
                var ezclear = transform.Find("ezclear").gameObject;
                ezclear.SetActive(true);
                break;
            case 2:
                var ezfc = transform.Find("ezfc").gameObject;
                ezfc.SetActive(true);
                break;
            case 3:
                var ezap = transform.Find("ezap").gameObject;
                ezap.SetActive(true);
                break;
            default:
                break;
        }
        switch (song.NLStatus)
        {
            case 1:
                var nlclear = transform.Find("nlclear").gameObject;
                nlclear.SetActive(true);
                break;
            case 2:
                var nlfc = transform.Find("nlfc").gameObject;
                nlfc.SetActive(true);
                break;
            case 3:
                var nlap = transform.Find("nlap").gameObject;
                nlap.SetActive(true);
                break;
            default:
                break;
        }
        switch (song.HDStatus)
        {
            case 1:
                var hdclear = transform.Find("hdclear").gameObject;
                hdclear.SetActive(true);
                break;
            case 2:
                var hdfc = transform.Find("hdfc").gameObject;
                hdfc.SetActive(true);
                break;
            case 3:
                var hdap = transform.Find("hdap").gameObject;
                hdap.SetActive(true);
                break;
            default:
                break;
        }
        switch (song.EXStatus)
        {
            case 1:
                var exclear = transform.Find("exclear").gameObject;
                exclear.SetActive(true);
                break;
            case 2:
                var exfc = transform.Find("exfc").gameObject;
                exfc.SetActive(true);
                break;
            case 3:
                var exap = transform.Find("exap").gameObject;
                exap.SetActive(true);
                break;
            default:
                break;
        }
        switch (PlayerPrefs.GetString("difficulty"))
        {
            case "easy":
                lvl.text = "LVL " + song.EZLevel;
                break;
            case "normal":
                lvl.text = "LVL " + song.NLLevel;
                break;
            case "hard":
                lvl.text = "LVL " + song.HDLevel;
                break;
            case "expert":
                lvl.text = "LVL " + song.EXLevel;
                break;
        }
    }

    void lvls() 
    {
        switch (PlayerPrefs.GetString("difficulty"))
        {
            case "easy":
                lvl.text = "LVL " + song.EZLevel;
                break;
            case "normal":
                lvl.text = "LVL " + song.NLLevel;
                break;
            case "hard":
                lvl.text = "LVL " + song.HDLevel;
                break;
            case "expert":
                lvl.text = "LVL " + song.EXLevel;
                break;
        }
    }

    public void clicked()
    {
        Image albumArt = GameObject.FindGameObjectWithTag("Image").GetComponent<Image>();
        Text hiScore = GameObject.FindGameObjectWithTag("hiscore").GetComponent<Text>();
        Text hiAcc = GameObject.FindGameObjectWithTag("hiacc").GetComponent<Text>();
        Text hiCombo = GameObject.FindGameObjectWithTag("hicombo").GetComponent<Text>();
        PlayerPrefs.SetString("selectedSong", song.name);
        var album = Resources.Load<Sprite>("Album Art/" + song.name);
        albumArt.sprite = album;
        switch (PlayerPrefs.GetString("difficulty"))
        {
            case "easy":
                hiScore.text = "HIGH SCORE: " + song.EZScore;
                hiAcc.text = "ACC: " + song.EZAcc + "%";
                hiCombo.text = "COMBO: " + song.EZCombo;
                break;
            case "normal":
                hiScore.text = "HIGH SCORE: " + song.NLScore;
                hiAcc.text = "ACC: " + song.NLAcc + "%";
                hiCombo.text = "COMBO: " + song.NLCombo;
                break;
            case "hard":
                hiScore.text = "HIGH SCORE: " + song.HDScore;
                hiAcc.text = "ACC: " + song.HDAcc + "%";
                hiCombo.text = "COMBO: " + song.HDCombo;
                break;
            case "expert":
                hiScore.text = "HIGH SCORE: " + song.EXScore;
                hiAcc.text = "ACC: " + song.EXAcc + "%";
                hiCombo.text = "COMBO: " + song.EXCombo;
                break;
        }
        
    }
}
