using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{

    public GameObject linePrefab;
    public Vector2 objectSize;
    private GameObject newLine;
    public Vector2 ClearLineup;
    public Vector2 ClearLinedown;

    private bool cl = false;
    public List<GameObject> squares;

    Line activeLine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
        }

        if(Input.GetMouseButtonUp(0))
        {
            activeLine = null;

            if (cl)
            {
                cl = false;
            }
            else
            {
                newLine.SetActive(false);
            }
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 마우스 위치를 게임 오브젝트 경계선 내부로 제한
            mousePos.x = Mathf.Clamp(mousePos.x, transform.position.x - objectSize.x / 2f, transform.position.x + objectSize.x / 2f);
            mousePos.y = Mathf.Clamp(mousePos.y, transform.position.y - objectSize.y / 2f, transform.position.y + objectSize.y / 2f);
            if(isLine(mousePos.x, mousePos.y))
            {
                cl = true;
            }
            activeLine.UpdateLine(mousePos);
        }
    }

   

    public bool isLine(float x, float y)
    {
        if(ClearLineup.x/2f > Math.Abs(x) || ClearLineup.y/2f > Math.Abs(y))
        {
            if((ClearLinedown.x/2f < Math.Abs(x) && ClearLinedown.y/2f < Math.Abs(y)))
            {
                return true;
            }
        }
        return false;
    }

}
