using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject LvlButton;
    public static LevelManager instance;
    public Transform Spacer;
    public List<LevelManager> LevelList;
    private string[][] Data;
    public Button EZ, NL, HD, EX;
    public List<Button> songButtons;
    public Text hiscore, hiacc, hicombo;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Data = File.ReadLines(@"Assets\Resources\songmenutest.csv").Select(x => x.Split(',')).ToArray();
        FillList();
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetString("difficulty", "easy");
        }
        if (!PlayerPrefs.HasKey("selectedSong"))
        {
            PlayerPrefs.SetString("selectedSong", "00000001");
        }
        var selected = GameObject.FindGameObjectWithTag(PlayerPrefs.GetString("selectedSong")).GetComponent<Setup>();
        selected.clicked();
        EZ.onClick.AddListener(EZClick);
        NL.onClick.AddListener(NLClick);
        HD.onClick.AddListener(HDClick);
        EX.onClick.AddListener(EXClick);
    }

    void FillList()
    {
        for (int i = 1; i < Data.Length; i++)
        {
            GameObject newButton = Instantiate(LvlButton) as GameObject;
            newButton.transform.tag = i.ToString("00000000");
            newButton.transform.SetParent(Spacer, false);
            newButton.GetComponent<Setup>().setup(i, Data);
            newButton.GetComponent<Setup>().lvlset(i, Data);
            songButtons.Add(newButton.GetComponent<Button>());
        }
    }

    void EZClick()
    {
        PlayerPrefs.SetString("difficulty", "easy");
        int i = 1;
        hiscore.text = "HIGH SCORE: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][11];
        hicombo.text = "COMBO: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][12];
        hiacc.text = "ACC: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][13] + "%";
        foreach (Button button in songButtons)
        {
            button.GetComponent<Setup>().lvlset(i, Data);
            i++;
        }
    }
    void NLClick()
    {
        PlayerPrefs.SetString("difficulty", "normal");
        int i = 1;
        hiscore.text = "HIGH SCORE: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][15];
        hicombo.text = "COMBO: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][16];
        hiacc.text = "ACC: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][17] + "%";
        foreach (Button button in songButtons)
        {
            button.GetComponent<Setup>().lvlset(i, Data);
            i++;
        }
    }
    void HDClick()
    {
        PlayerPrefs.SetString("difficulty", "hard");
        int i = 1;
        hiscore.text = "HIGH SCORE: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][19];
        hicombo.text = "COMBO: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][20];
        hiacc.text = "ACC: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][21] + "%";
        foreach (Button button in songButtons)
        {
            button.GetComponent<Setup>().lvlset(i, Data);
            i++;
        }
    }
    void EXClick()
    {
        PlayerPrefs.SetString("difficulty", "expert");
        int i = 1;
        hiscore.text = "HIGH SCORE: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][23];
        hicombo.text = "COMBO: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][24];
        hiacc.text = "ACC: " + Data[int.Parse(PlayerPrefs.GetString("selectedSong"))][25] + "%";
        foreach (Button button in songButtons)
        {
            button.GetComponent<Setup>().lvlset(i, Data);
            i++;
        }
    }

    public string Lookup(int x, int y)
    {
        return Data[x][y];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
