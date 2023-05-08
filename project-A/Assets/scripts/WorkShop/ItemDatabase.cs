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
    {// % 넣기
        items = new List<Item>() {
            new Item(0, "갈색 가방", "주운 가방",
            new Dictionary<string, int> {
                { "오염도 10%", 10 }
            }),
            new Item(1, "붉은색 가방", "주운 가방",
            new Dictionary<string, int> {
                { "오염도 15%", 15 }
            }),
            new Item(2, "검정색 가방", "주운 가방",
            new Dictionary<string, int> {
                { "오염도 20%", 20 }
            }),
            new Item(3, "오염된 갈색 가방", "주운 가방",
            new Dictionary<string, int> {
                { "오염도 60%", 60 }
            }),
            new Item(10, "갈색 가죽", "가죽",
            new Dictionary<string, int> {
                { "오염도 10%", 10 }
            }),
            new Item(11, "붉은색 가죽", "가죽",
            new Dictionary<string, int> {
                { "오염도 15%", 15 }
            }),
            new Item(12, "검정색 가죽", "가죽",
            new Dictionary<string, int> {
                { "오염도 20%", 20 }
            }),
            new Item(13, "오염된 갈색 가죽", "가죽",
            new Dictionary<string, int> {
                { "오염도 60%", 60 }
            }),
            new Item(20, "투톤 베이직 가방", "수제 가방",
            new Dictionary<string, int> {
                { "가격", 400 }
            }),
            new Item(21, "브이 크로스 베이직 가방", "수제 가방",
            new Dictionary<string, int> {
                { "가격", 1000 }
            }),
            new Item(22, "브이 크로스 장미 가방", "수제 가방",
            new Dictionary<string, int> {
                { "가격", 8000 }
            }),
        };
    }
}
