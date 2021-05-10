using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class NoteCreate : MonoBehaviour
{
    public GameObject hitNote;
    public GameObject holdNote;
    public GameObject catchNote;
    public GameObject NoteParent;

    void OnEnable()
    {
        NoteParent = this.gameObject;
    }

    public void HitNoteCreate()
    {
        var makeNote = Instantiate(hitNote, this.transform.localPosition, this.transform.localRotation);
        makeNote.transform.parent = NoteParent.transform;
        makeNote.transform.localPosition = this.transform.localPosition;
        makeNote.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        makeNote.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void HoldNoteCreate(float holdLength)
    {
        var makeNote = Instantiate(holdNote, this.transform.localPosition, this.transform.localRotation);
        makeNote.transform.parent = NoteParent.transform;
        makeNote.transform.localPosition = this.transform.localPosition;
        makeNote.transform.localRotation = Quaternion.Euler(-90f,0f,0f);
        makeNote.transform.localScale = new Vector3(0f, 0f, 0f);
        makeNote.GetComponent<HoldNoteMovement>().noteHoldTime = holdLength;
    }

    public void CatchNoteCreate()
    {
        var makeNote = Instantiate(catchNote, this.transform.localPosition, this.transform.localRotation);
        makeNote.transform.parent = NoteParent.transform;
        makeNote.transform.localPosition = this.transform.localPosition;
        makeNote.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        makeNote.transform.localScale = new Vector3(0f, 0f, 0f);
    }
}
