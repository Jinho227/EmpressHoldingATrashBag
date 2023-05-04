using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    public List<UIItem> recyclingBagUiItems = new List<UIItem>();
    public List<UIItem> leatherUiItems = new List<UIItem>();
    public List<UIItem> makingBagUiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform RecyclingSlotPanel;
    public Transform leahterSlotPanel;
    public Transform makingBagSlotPanel;

    void Awake()
    {
        MakeInventory(recyclingBagUiItems, RecyclingSlotPanel);
        MakeInventory(leatherUiItems, leahterSlotPanel);
        MakeInventory(makingBagUiItems, makingBagSlotPanel);
    }

    

    public void MakeInventory(List<UIItem> uiItem, Transform slotPanel)
    {
        for (int i = 0; i < 45; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItem.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, Item item, List<UIItem> tempUiItem)
    {
        tempUiItem[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        List<UIItem> tempUiItem = WhatTypeItem(item);
        UpdateSlot(tempUiItem.FindIndex(i=> i.item == null), item, tempUiItem);
    }

    public void RemoveItem(Item item)
    {
        List<UIItem> tempUiItem = WhatTypeItem(item);
        UpdateSlot(tempUiItem.FindIndex(i=> i.item == item), null, tempUiItem);
    }


    public List<UIItem> WhatTypeItem(Item item)
    {
        if (item.id >= 20)
        {
            return makingBagUiItems;
        }
        else if (item.id >= 10)
        {
            return leatherUiItems;
        }
        else if (item.id >= 0)
        {
            return recyclingBagUiItems;
        }
        else
        {
            return null;
        }

    }
}
