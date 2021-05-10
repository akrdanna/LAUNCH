using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource Music;
    public bool startPlaying;
    public static GameManager instance;
    public int currentScore;
    public int scorePerGoodNote;
    public int scorePerPerfectNote;
    public TextMesh scoreText;
    public string format = "#,###,###";
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public int comboTracker;
    public TextMesh comboText;
    public TextMesh accText;
    public Pause pause;
    private int counter = 0;
    public int noOfPerfect = 0;
    public int noOfGood = 0;
    public int noOfMiss = 0;
    public int maxCombo = 0;
    public int maxComboTemp = 0;
    public int noteCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        pause.gameIsPaused = false;
        instance = this;
        Invoke("PlayMusic", 4.75f);
    }

    void PlayMusic()
    {
        //Music.volume = PlayerPrefs.GetFloat("musicVolume");
        Music.Play();
        startPlaying = true;
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 1 && !Music.isPlaying)
        {
            DontDestroyOnLoad(this.gameObject);
            //SceneManager.LoadScene("Results", LoadSceneMode.Additive);
            counter = 0;
        }
    }
    public void NoteHit()
    {
        noteCount += 1;
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = currentScore.ToString(format);
        if (comboTracker > 1)
        {
            comboText.text = (comboTracker + 1).ToString();
        }
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        accText.text = "GOOD";
        noOfGood += 1;
        //NoteHit();
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        accText.text = "PERFECT";
        noOfPerfect += 1;
        //NoteHit();
    }
    public void NoteMissed()
    {
        noteCount += 1;
        accText.text = "MISS";
        comboTracker = 0;
        comboText.text = "";
        currentMultiplier = 1;
        multiplierTracker = 0;
        noOfMiss += 1;
        if (maxCombo > maxComboTemp)
        {
            maxComboTemp = maxCombo;
            maxCombo = 0;
        }
    }
}
