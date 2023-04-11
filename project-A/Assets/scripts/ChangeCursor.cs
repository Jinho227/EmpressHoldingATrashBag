using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;

    public void ChangeCursorN()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }
}
