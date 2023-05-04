using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D NomalCursor;
    public Texture2D cursorFiveFingers;
    public Texture2D cursorGrab;
    public Texture2D cursorHammer;
    public Texture2D cursorHammerDown;
    public Texture2D cursorNeedle;
    public enum cursorMode
    {
        Nomal, Hammer, needle
    }
    private int cursorModeIndex = (int)cursorMode.Nomal;

    public int CursorModeIndex { get => cursorModeIndex; set => cursorModeIndex = value; }

    public void ChangeCursorImage(Texture2D cursorImage)
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }
}
