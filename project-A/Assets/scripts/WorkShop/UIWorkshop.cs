using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWorkshop : MonoBehaviour
{
    public Item item;
    public GameObject slotPrefab;
    private UIItem selectedItem;


    void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        IsSelectedItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void IsSelectedItem()
    {
        if (selectedItem.item != null)
        {
            Debug.Log("isSelectedItem");
        }
    }
}
