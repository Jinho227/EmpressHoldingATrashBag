using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    void Start()
    {
        dataLoad();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            //inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Removed item: " + itemToRemove.title);
        }
    }

    public void dataSave()
    {
        for (int i = 0; i < characterItems.Count; i++)
        {
            PlayerPrefs.SetInt("playerItems" + i, characterItems[i].id);
        }
        PlayerPrefs.SetInt("PlayerItemsIndex", characterItems.Count);
        PlayerPrefs.Save();
    }
    public void dataLoad()
    {
        int index = PlayerPrefs.GetInt("PlayerItemsIndex", 0);
        for (int i = 0; i < index; i++)
        {
            GiveItem(PlayerPrefs.GetInt("playerItems" + i, -1));
        }
        index = PlayerPrefs.GetInt("PickUpItemsIndex", 0);
        for (int i = 0; i < index; i++)
        {
            GiveItem(PlayerPrefs.GetInt("PickUpItems" + i, -1));
        }

    }

    public void ChangeStore()
    {
        dataSave();
        SceneManager.LoadScene("StoreScene");
    }
}
