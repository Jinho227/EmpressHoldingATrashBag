using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public SewLeather sewleather;
    public GameObject canvas;
    public LineRenderer lr;
    public EdgeCollider2D col;
    public Inventory inventory;
    List<Vector2> points = new List<Vector2>();
    public LeatherSetting leatherSetting;

    private void Awake()
    {
    }

    struct MakingBag
    {
        public int[] leather;
        public int bagId;
    }

    MakingBag bag20 = new MakingBag();
    MakingBag bag21 = new MakingBag();

    private void Start()
    {
        bag20.leather = new int[3];
        bag20.leather[0] = 11;
        bag20.leather[1] = 10;
        bag20.leather[2] = 11;
        bag20.bagId = 20;

        bag21.leather = new int[2];
        bag21.leather[0] = 12;
        bag21.leather[1] = 10;
        bag21.bagId = 21;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //go = Instantiate(linePrefab);
            //lr = go.GetComponent<LineRenderer>();
            //col = go.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.positionCount = 1;
            lr.SetPosition(0, points[0]);
            lr.transform.position = new Vector3(0, 0, 0);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            points.Add(pos);
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, pos);
            col.points = points.ToArray();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //sewleather = GameObject.Find("Line(Clone)").GetComponent<SewLeather>();
            int id = IsSewLeather();
            if(id >= 20)
            {
                canvas.SetActive(true);
                leatherSetting.MakingBag();
                inventory.GiveItem(id);
            }
            else
            {
                Debug.Log(id);
                //Destroy(go);
            }
            sewleather.leatherid.Clear();
            lr.positionCount = 1;
            points.Clear();
        }
    }



    public int IsSewLeather()
    {
        int value = -1;
        for(int i = 0; i < sewleather.leatherid.Count; i++)
        {
            if(sewleather.leatherid.Count != 3)
            {
                break;
            }
            Debug.Log(sewleather.leatherid[i]);
            if(bag20.leather[i] == sewleather.leatherid[i])
            {
                value = 21;
            }
            else
            {
                value = -1;
                break;
            }

        }
        if(value == 21)
        {
            return value;
        }
        for (int i = 0; i < sewleather.leatherid.Count; i++)
        {
            if (bag21.leather[i] == sewleather.leatherid[i])
            {
                value = 20;
            }
            else
            {
                value = -1;
                break;
            }

        }
        return value;
    }

}
