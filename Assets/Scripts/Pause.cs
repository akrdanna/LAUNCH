using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public ResumeScript resume;
    public GameObject resume2;
    public AudioSource audio;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(GoHere);
    }

    // Update is called once per frame
    void GoHere()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        audio.Pause();
        gameIsPaused = true;
    }

    public void Resume()
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        resume2.SetActive(true);
        resume.StartHere();
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                GameIsPaused = false;
                resume2.SetActive(true);
                resume.Start();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                audio.Pause();
                GameIsPaused = true;
            }
        }
    }*/
}
