using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if(percentage > 0)
            {
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0)
            {
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            transform.position = newLocation;
            panelLocation = newLocation;
        }
        else
        {
            transform.position = panelLocation;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
