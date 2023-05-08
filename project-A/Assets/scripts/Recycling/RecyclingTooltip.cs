using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecyclingTooltip : MonoBehaviour
{
    public Image tooltipImage;
    // Start is called before the first frame update
    void Start()
    {
        //tooltipImage = GetComponentInChildren<Image>();
        gameObject.SetActive(false);
    }

    public void GTooltip(int id)
    {
        if(id == 0)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "���� ����");
        } 
        else if(id == 1)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "������ ����");
        }
        else if(id == 2)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "������ ����");
        }
        else if(id == 3)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "������ ���� ����");
        }
        gameObject.SetActive(true);
    }
}
