using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int id;
    public string title;
    public string type;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string type, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.type = type;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.type = item.type;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.title);
        this.stats = item.stats;
    }
}
