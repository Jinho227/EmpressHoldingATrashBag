using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;
    private ChangeCursor cursor;

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
        if (this.item != null)
        {
            if (this.item.id < 10)
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
        else
        {

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
