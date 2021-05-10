using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    private new Transform transform;
    public Collider noteCollider;
    private Vector3 scaleTarget;
    private Vector3 scaleStart;
    private Vector3 halfScaleTarget;
    private float growDuration = 0.2f;
    float t = 0;
    float u = 0;
    float v = 0;
    private bool perfect;
    private bool grow;
    public Pause pause;

    // Start is called before the first frame update
    void OnEnable()
    {
        pause = GameObject.Find("PauseManager").GetComponent<Pause>();
        perfect = false;
        grow = true;
        transform = GetComponent<Transform>();
        scaleStart = new Vector3(0f, 0f, 0f);
        scaleTarget = new Vector3(8.016f, 8.016f, 8.016f);
        halfScaleTarget = new Vector3(4.008f, 4.008f, 4.008f);
        t = 0;
        u = 0;
        v = 0;
        noteCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / growDuration;
        u += Time.deltaTime;
        if (grow)
        {
            Vector3 newScale = Vector3.Lerp(scaleStart, scaleTarget, t);
            transform.localScale = newScale;

            if (transform.localScale == halfScaleTarget)
            {
                perfect = true;
            }

            if (transform.localScale == scaleTarget)
            {
                grow = false;
                //t = 0;
            }
        }
        if (!grow && u >= 0.15f+growDuration)
        {
            v += Time.deltaTime / growDuration;
            Vector3 newScale = Vector3.Lerp(scaleTarget, scaleStart, v);
            transform.localScale = newScale;

            if (transform.localScale == halfScaleTarget)
            {
                perfect = false;
            }

            if (transform.localScale == scaleStart)
            {
                GameManager.instance.NoteMissed();
                Destroy(gameObject);
            }
        }
        foreach (Touch touch in Input.touches)
        {
            //Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    Hit();
                }
            }
        }
    }
    public void Hit()
    {
        if (!pause.gameIsPaused)
        {
            if (perfect)
            {
                GameManager.instance.PerfectHit();
            }
            else if (!perfect)
            {
                GameManager.instance.GoodHit();
            }
            GameManager.instance.comboTracker += 1;
            Destroy(gameObject);
        }
    }           
}
