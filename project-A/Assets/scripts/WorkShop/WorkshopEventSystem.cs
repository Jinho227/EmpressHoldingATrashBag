using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkshopEventSystem : MonoBehaviour
{
    [SerializeField] ChangeCursor cursor;
    [SerializeField] GameObject leatherPanel;
    // Start is called before the first frame update
    void Awake()
    {
        cursor.ChangeCursorImage(cursor.cursorFiveFingers);
    }

    void Start()
    {
        leatherPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WhatCursor();   
    }

    public void WhatCursor()
    {
        if (cursor.CursorModeIndex == 0)
        {
            MouseClick(cursor.cursorFiveFingers, cursor.cursorGrab);
        }
        if (cursor.CursorModeIndex == 1)
        {
            MouseClick(cursor.cursorHammer, cursor.cursorHammerDown);
        }
        if (cursor.CursorModeIndex == 2)
        {
            MouseClick(cursor.cursorNeedle, cursor.cursorNeedle);
        }
    }
    public void MouseClick(Texture2D buttonUpImage, Texture2D buttonDownImage)
    {
        if (Input.GetMouseButtonDown(0))
        {
            cursor.ChangeCursorImage(buttonDownImage);
        }
        if (Input.GetMouseButtonUp(0))
        {
            cursor.ChangeCursorImage(buttonUpImage);
        }
    }
}
