using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpBagInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int bagid;
    public bool bagBool = false;
    private RecyclingTooltip tooltip;

    void Awake()
    {
        tooltip = GameObject.Find("Tooltip").GetComponent<RecyclingTooltip>();
        bagBool = false;
    }

    public void BagBool(bool b)
    {
        bagBool = b;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.GTooltip(bagid);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
