using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bagtooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BagItemInfo bagitem;
    public StoreTooltip tooltip;

    void Awake()
    {
        //tooltip = GameObject.Find("tooltip").GetComponent<StoreTooltip>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.STooltip(bagitem.EstimatedPrice);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
