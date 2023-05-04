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
            new Item(0, "고급스러워 보이는 원형천가방", "주운 가방",
            new Dictionary<string, int> {
                { "오염도", 15 },
            }),
            new Item(1, "두꺼운 서민가방", "주운 가방",
            new Dictionary<string, int> {
                { "오염도", 30 }
            }),
            new Item(2, "고급스러워 보이는 원형천가방(정면)", "주운 가방",
            new Dictionary<string, int> {
                { "오염도", 5 },
            }),
            new Item(10, "검정 가죽", "가죽",
            new Dictionary<string, int> {
            }),
            new Item(11, "황토색 가죽", "가죽",
            new Dictionary<string, int> {
            }),
            new Item(12, "갈색 가죽", "가죽",
            new Dictionary<string, int> {
            }),
            new Item(20, "서민 가방", "수제 가방",
            new Dictionary<string, int> {
                { "가격", 400 }
            }),
            new Item(21, "평민 가방", "수제 가방",
            new Dictionary<string, int> {
                { "가격", 1000 }
            }),
            new Item(22, "귀족 가방", "수제 가방",
            new Dictionary<string, int> {
                { "가격", 8000 }
            }),
        };
    }
}
