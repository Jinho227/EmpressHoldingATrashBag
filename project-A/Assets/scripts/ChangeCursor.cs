using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D defaultCursor;
    [SerializeField] Texture2D cursorFiveFingers;
    [SerializeField] Texture2D cursorGrab;

    public void ChangeCursorN()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ChangeCursorFiveFingers()
    {
        Cursor.SetCursor(cursorFiveFingers, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ChangeCursorGrab()
    {
        Cursor.SetCursor(cursorGrab, Vector2.zero, CursorMode.ForceSoftware);
    }
}
