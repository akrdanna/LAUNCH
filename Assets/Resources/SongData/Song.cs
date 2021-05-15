using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Song", menuName = "Song")]
public class Song : ScriptableObject
{
    public bool isLocked, isFaved; 

    public string title;
    public string artist;

    public string EZLevel;
    public string NLLevel;
    public string HDLevel;
    public string EXLevel;

    public string EZScore;
    public string NLScore;
    public string HDScore;
    public string EXScore;

    public string EZAcc;
    public string NLAcc;
    public string HDAcc;
    public string EXAcc;

    public string EZCombo;
    public string NLCombo;
    public string HDCombo;
    public string EXCombo;

    public string EZRank, NLRank, HDRank, EXRank;

    public Sprite albumart;

    public int EZStatus;
    public int NLStatus;
    public int HDStatus;
    public int EXStatus;
}
