using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeScript : MonoBehaviour
{
    public float timeLeft;
    public GameObject pauseMenuUI;
    public Text countdown;
    public Pause pause;
    public GameObject comboText;
    public GameObject scoreText;
    public AudioSource audio;
    // Start is called before the first frame update
    public void StartHere()
    {
        timeLeft = 3.0f;
        pauseMenuUI.SetActive(false);
        comboText.SetActive(false);
        scoreText.SetActive(false);
        countdown.text = (timeLeft).ToString("0");
        StartCoroutine(Countdown(timeLeft));
        StopCoroutine(Countdown(timeLeft));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Countdown(float timeLeft)
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
            countdown.text = (timeLeft).ToString("0");
        }
        countdown.text = "";
        comboText.SetActive(true);
        scoreText.SetActive(true);
        Time.timeScale = 1f;
        audio.UnPause();
        pause.gameIsPaused = false;
        gameObject.SetActive(false);
    }
}
