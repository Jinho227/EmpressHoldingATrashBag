using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreTooltip : MonoBehaviour
{
    public Text tooltipText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }

    public void STooltip(int estimatePrice)
    {

        tooltipText.text = "���󰡰�(�մ��� ��) " + estimatePrice + "F";
        gameObject.SetActive(true);
    }
}
