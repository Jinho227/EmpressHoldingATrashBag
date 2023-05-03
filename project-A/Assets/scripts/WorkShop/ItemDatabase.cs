using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item=> item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "고급스러워 보이는 원형천가방", "고급스러운 원형천가방이다.",
            new Dictionary<string, int> {
                { "Power", 15 },
                { "Defence", 10 }
            }),
            new Item(1, "두꺼운 서민가방", "A pretty diamond.",
            new Dictionary<string, int> {
                { "Value", 300 }
            }),
            new Item(2, "고급스러워 보이는 원형천가방(정면)", "A pick that could kill a vampire.",
            new Dictionary<string, int> {
                { "Power", 5 },
                { "Mining", 20}
            })
        };
    }
}
