using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeatherSetting : MonoBehaviour
{
    public LeatherItem leatheritem;
    public SpriteRenderer Leather1;
    public SpriteRenderer Leather2;
    public SpriteRenderer Leather3;
    public Image LeatherImage1;
    public Image LeatherImage2;
    public Image LeatherImage3;

    public SewLeather sewleather;
    public Inventory inventory;

    public void NeedleClick()
    {
        if(leatheritem.leatheritem1.item != null)
        {
            Leather1.color = Color.white;
            Leather1.sprite = leatheritem.leatheritem1.item.icon;
            sewleather.l1 = leatheritem.leatheritem1.item.id;
        }
        else
        {
            Leather1.color = Color.clear;
            sewleather.l1 = -1;
        }
        if (leatheritem.leatheritem2.item != null)
        {
            Leather2.color = Color.white;
            Leather2.sprite = leatheritem.leatheritem2.item.icon;
            sewleather.l2 = leatheritem.leatheritem2.item.id;
        }
        else
        {
            Leather2.color = Color.clear;
            sewleather.l2 = -1;
        }
        if (leatheritem.leatheritem3.item != null)
        {
            Leather3.color = Color.white;
            Leather3.sprite = leatheritem.leatheritem3.item.icon;
            sewleather.l3 = leatheritem.leatheritem3.item.id;
        }
        else
        {
            Leather3.color = Color.clear;
            sewleather.l3 = -1;
        }
    }

    public void MakingBag()
    {
        if (leatheritem.leatheritem1.item != null)
        {
            inventory.RemoveItem(sewleather.l1);
            leatheritem.leatheritem1.item = null;
            LeatherImage1.color = Color.clear;

        }
        else
        {
        }
        if (leatheritem.leatheritem2.item != null)
        {
            inventory.RemoveItem(sewleather.l2);
            leatheritem.leatheritem2.item = null;
            LeatherImage2.color = Color.clear;
        }
        else
        {
        }
        if (leatheritem.leatheritem3.item != null)
        {
            inventory.RemoveItem(sewleather.l3);
            leatheritem.leatheritem3.item = null;
            LeatherImage3.color = Color.clear;
        }
        else
        {
        }
        
        
        
    }
}
