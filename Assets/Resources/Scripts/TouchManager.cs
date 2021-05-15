using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public List<ButtonOnOff> ActiveButtons = new List<ButtonOnOff>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach (var btn in ActiveButtons)
            {
                if (btn.LockedFingerID == null)
                {
                    if ((Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Moved )&&
                        btn.buttonCollider.OverlapPoint(touchWorldPos))
                    {
                        btn.LockedFingerID = Input.GetTouch(i).fingerId;
                        btn.buttonOn();
                    }
                }
                else if (btn.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
                    {
                        btn.LockedFingerID = null;
                        btn.buttonOff();
                    }
                    else if (!btn.buttonCollider.OverlapPoint(touchWorldPos))
                    {
                        btn.LockedFingerID = null;
                        btn.buttonOff();
                    }
                }
            }
        }
    }
}
