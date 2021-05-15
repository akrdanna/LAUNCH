using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Reader : MonoBehaviour
{
    private int Line = 0;
    private string selector;
    private string[][] Map;
    private float time;
    private float offset;
    // Start is called before the first frame update
    void Awake()
    {
        //offset = PlayerPrefs.GetFloat("Offset");
        Map = File.ReadLines(@"Assets\Resources\Maps\" + PlayerPrefs.GetString("selectedSong") + "-" + PlayerPrefs.GetString("difficulty") + ".csv").Select(x => x.Split(',')).ToArray();
        Line = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        try
        {
            if ((time /*- offset*/) >= float.Parse(Map[Line][0]) && Line < Map.Length)
            {
                selector = Map[Line][1];
                GameObject GO = GameObject.FindWithTag(selector);
                if (int.Parse(Map[Line][2]) == 1)
                {
                    GO.GetComponent<NoteCreate>().HitNoteCreate();
                }
                if (int.Parse(Map[Line][2]) == 2)
                {
                    Debug.Log("Hi");
                    GO.GetComponent<NoteCreate>().CatchNoteCreate();
                }
                if (int.Parse(Map[Line][2]) == 3)
                {
                    float holdLength = float.Parse(Map[Line][3]);
                    GO.GetComponent<NoteCreate>().HoldNoteCreate(holdLength);
                }

                Line++;
            }
        }
        catch (System.IndexOutOfRangeException)
        {
            return;
        }
    }
}
