using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public TextMeshProUGUI equipItemCount;
    public TextMeshProUGUI totalItemCount;

    public Image[] itemIcons;

    public List<UISlot> slots;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI statNameText;
    public TextMeshProUGUI statValueText;

    

    public void InitSlot(UISlot slot, ItemData item, int quantity)
    {
        slot.item = item;
        slot.quantity = quantity;
        slot.equipped = false;
        slot.Set();
    }
    public void UpdateInventoryUI()
    {
        int equippedCount = 0;
        int totalCount = 0;

        foreach (var slot in slots)
        {
            if (slot.item != null)
            {
                totalCount++;
                if (slot.equipped) equippedCount++;
            }
        }

        equipItemCount.text = $"장착 {equippedCount}";
        totalItemCount.text = $"전체 {totalCount}";
    }

    public void ShowItemInfo(ItemData item)
    {
        nameText.text = item.displayName;
        descText.text = item.description;

        if (item is ItemData eq && eq.equipableData != null)
        {
            statNameText.text = $"[{eq.equipableData.type}]";
            statValueText.text = eq.equipableData.value.ToString("F1");
        }
        else
        {
            statNameText.text = "-";
            statValueText.text = "-";
        }
    }
}
