using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource chosen;
    // Start is called before the first frame update
    void Awake()
    {
        chosen = GetComponent<AudioSource>();
        chosen.clip = Resources.Load<AudioClip>("Music/" + PlayerPrefs.GetString("selectedSong"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
