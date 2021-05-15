using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOnOff : MonoBehaviour
{
    public Collider2D buttonCollider;
    public Button thisButton;
    private Image switchImage;
    public Pause pause;
    public TouchManager Controller;
    [SerializeField]
    private Sprite[] switchSprites;
    public int? LockedFingerID { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        buttonCollider = gameObject.GetComponent<Collider2D>();
        switchImage = gameObject.GetComponent<Image>();
        switchImage.sprite = switchSprites[0];
    }

    // Update is called once per frame
    public void buttonOn()
    {
        switchImage.sprite = switchSprites[1];
    }
    public void buttonOff()
    {
        switchImage.sprite = switchSprites[0];
    }
    private void OnEnable()
    {
        if (!pause.gameIsPaused)
        {
            Controller.ActiveButtons.Add(this);
        }
    }
    private void OnDisable()
    {
        if (!pause.gameIsPaused)
        {
            Controller.ActiveButtons.Remove(this);
        }
    }
    
    void Update()
    {
        if (pause.gameIsPaused)
        {
            thisButton.interactable = false;
        }
    }
}
