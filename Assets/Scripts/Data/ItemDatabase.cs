using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private static Dictionary<string, ItemData> itemDict;

    public static void Initialize()
    {
        if (itemDict != null) return;

        itemDict = new Dictionary<string, ItemData>();
        var items = Resources.LoadAll<ItemData>("Items");

        foreach (var item in items)
        {
            if (!itemDict.ContainsKey(item.itemId))
                itemDict[item.itemId] = item;
        }
    }

    public static ItemData GetItemById(string id)
    {
        Initialize();
        itemDict.TryGetValue(id, out var item);
        return item;
    }
}
