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
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "갈색 가방");
        } 
        else if(id == 1)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "붉은색 가방");
        }
        else if(id == 2)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "검정색 가방");
        }
        else if(id == 3)
        {
            tooltipImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + "오염된 갈색 가방");
        }
        gameObject.SetActive(true);
    }
}
