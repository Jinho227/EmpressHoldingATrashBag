using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    public Item item;
    public Inventory inventory;
    private Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;
    private ChangeCursor cursor;
    private int count = 0;

    void Awake()
    {
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
        spriteImage = GetComponent<Image>();
        cursor = GameObject.Find("EventSystem").GetComponent<ChangeCursor>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cursor.CursorModeIndex == 0)
        {
            IsSelectedItem();
        }
        else if(cursor.CursorModeIndex == 1)
        {
            DecompositionItem();
        }
        else if(cursor.CursorModeIndex == 2)
        {

        }
    }

    public int SettingLeather()
    {
        return this.item.id;
    }

    public void IsSelectedItem()
    {
        if (this.item != null)
        {
            if (selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        else if (selectedItem.item != null)
        {
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }

    public void DecompositionItem()
    {
        if (this.item != null && (this.item.id < 10))
        {
            if (count < 2)
            {
                GiveLeather(this.item.id);
                count++;
            }
            else
            {
                inventory.RemoveItem(this.item.id);
                this.item = null;
                spriteImage.color = Color.clear;
                count = 0;
            }
        }
        else
        {

        }
    }

    public void GiveLeather(int id)
    {
        if(id == 0)
        {
            inventory.GiveItem(10);
        }
        else if(id == 1)
        {
            inventory.GiveItem(11);
        }
        else if(id == 2)
        {
            inventory.GiveItem(12);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       if (this.item != null)
       {
            tooltip.GenerateTooltip(this.item);
       }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
