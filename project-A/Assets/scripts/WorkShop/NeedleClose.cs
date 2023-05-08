using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleClose : MonoBehaviour
{
    public ChangeCursor cc;
    public GameObject canvas;
    public GameObject Draw;
    public GameObject needle;
    public GameObject needledown;
    void OnMouseDown()
    {
        cc.CursorModeIndex = 0;
        canvas.SetActive(true);
        Draw.SetActive(false);
        needle.SetActive(true);
        needledown.SetActive(false);
    }
}
