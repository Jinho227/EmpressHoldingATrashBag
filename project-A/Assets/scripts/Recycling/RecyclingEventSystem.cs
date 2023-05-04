using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingEventSystem : MonoBehaviour
{
    [SerializeField] ChangeCursor cursor;
    // Start is called before the first frame update
    void Awake()
    {
        cursor.ChangeCursorImage(cursor.cursorFiveFingers);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            cursor.ChangeCursorImage(cursor.cursorGrab);
        }
        if (Input.GetMouseButtonUp(0))
        {
            cursor.ChangeCursorImage(cursor.cursorFiveFingers);
        }
    }

    
}
