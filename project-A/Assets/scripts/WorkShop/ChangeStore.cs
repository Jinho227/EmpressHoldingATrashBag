using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStore : MonoBehaviour
{
    public Inventory player;

    public void dataSave()
    {
        for(int i = 0; i < player.characterItems.Count; i++)
        {
            PlayerPrefs.SetInt("playerItems" + i, player.characterItems[i].id);
        }

    }
    public void dataLoad()
    {

    }
}
