using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour
{
    // Start is called before the first frame update
    public void toGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void toHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void songSelect()
    {
        SceneManager.LoadScene("SongSelect");
    }

    public void toProfile()
    {
        SceneManager.LoadScene("Profile");
    }

    public void toShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void toGear()
    {
        SceneManager.LoadScene("MyGear");
    }

    public void toEvents()
    {
        SceneManager.LoadScene("Events");
    }

    public void toSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
