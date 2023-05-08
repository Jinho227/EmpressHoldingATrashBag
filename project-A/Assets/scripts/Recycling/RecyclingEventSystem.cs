using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecyclingEventSystem : MonoBehaviour
{
    [SerializeField] ChangeCursor cursor;
    [SerializeField] PickUpBagInfo[] bag;

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

    public void ChangeScene()
    {
        dataSave();
        SceneManager.LoadScene("WorkshopScene");
    }

    private void dataSave()
    {
        int index = 0;
        for(int i = 0; i < 4; i++)
        {
            if(bag[i].bagid != -1)
            {
                PlayerPrefs.SetInt("PickUpItems" + i, bag[i].bagid);
                index++;
            }
        }
        PlayerPrefs.SetInt("PickUpItemsIndex", index);
    }

    public void dataDelete()
    {
        PlayerPrefs.DeleteAll();
    }

}
