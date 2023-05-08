using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewLeather : MonoBehaviour
{
    public List<int> leatherid = new List<int>();
    public int l1 = -1;
    public int l2 = -1;
    public int l3 = -1;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Leather")
        {
            leatherid.Add(l1);
        }
        if (col.gameObject.name == "Leather2")
        {
            leatherid.Add(l2);
        }
        if (col.gameObject.name == "Leather3")
        {
            leatherid.Add(l3);
        }
    }
}
