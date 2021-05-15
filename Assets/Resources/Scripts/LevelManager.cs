using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Button EZ, NL, HD, EX;
    public Text hiscore, hiacc, hicombo;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetString("difficulty", "easy");
        }
        if (!PlayerPrefs.HasKey("selectedSong"))
        {
            PlayerPrefs.SetString("selectedSong", "00000001");
        }
        var selected = GameObject.Find(PlayerPrefs.GetString("selectedSong")).GetComponent<Setup>();
        selected.clicked();
        EZ.onClick.AddListener(EZClick);
        NL.onClick.AddListener(NLClick);
        HD.onClick.AddListener(HDClick);
        EX.onClick.AddListener(EXClick);
    }

    void EZClick()
    {
        PlayerPrefs.SetString("difficulty", "easy");
        var selected = GameObject.Find(PlayerPrefs.GetString("selectedSong")).GetComponent<Setup>();
        hiscore.text = "HIGH SCORE: " + selected.song.EZScore;
        hicombo.text = "COMBO: " + selected.song.EZCombo;
        hiacc.text = "ACC: " + selected.song.EZAcc + "%";
    }
    void NLClick()
    {
        PlayerPrefs.SetString("difficulty", "normal");
        var selected = GameObject.Find(PlayerPrefs.GetString("selectedSong")).GetComponent<Setup>();
        hiscore.text = "HIGH SCORE: " + selected.song.NLScore;
        hicombo.text = "COMBO: " + selected.song.NLCombo;
        hiacc.text = "ACC: " + selected.song.NLAcc + "%";
    }
    void HDClick()
    {
        PlayerPrefs.SetString("difficulty", "hard");
        var selected = GameObject.Find(PlayerPrefs.GetString("selectedSong")).GetComponent<Setup>();
        hiscore.text = "HIGH SCORE: " + selected.song.HDScore;
        hicombo.text = "COMBO: " + selected.song.HDCombo;
        hiacc.text = "ACC: " + selected.song.HDAcc + "%";
    }
    void EXClick()
    {
        PlayerPrefs.SetString("difficulty", "expert");
        var selected = GameObject.Find(PlayerPrefs.GetString("selectedSong")).GetComponent<Setup>();
        hiscore.text = "HIGH SCORE: " + selected.song.EXScore;
        hicombo.text = "COMBO: " + selected.song.EXCombo;
        hiacc.text = "ACC: " + selected.song.EXAcc + "%";
    }
}
