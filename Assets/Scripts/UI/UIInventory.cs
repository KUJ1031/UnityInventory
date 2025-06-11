using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static SaveData;

public class UIInventory : MonoBehaviour
{
    [Header("착용 중 아이템 갯수 / 착용 가능 아이템 갯수")]
    public TextMeshProUGUI equipItemCount;
    public TextMeshProUGUI totalItemCount;

    [Header("아이템 아이콘")]
    public Image[] itemIcons;

    [Header("연결 슬롯들")]
    public List<UISlot> slots;

    [Header("이름 및 아이템 설명")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI statNameText;
    public TextMeshProUGUI statValueText;

    [Header("아이템 효과")]
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI CriticalText;

    [Header("장착/해제")]
    public TextMeshProUGUI equipButtonText;

    [Header("선택된 아이템")]
    public ItemData selectedItem;

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

    public void ShowStatusInfo(ItemData item)
    {
        var character = GameManager.Instance?.PlayerCharacter;

        attackText.text = "공격력 : " + character.Attack.ToString();
        defenseText.text = "방어력 : " + character.Defense.ToString();
        hpText.text = "체력 : " + character.Hp.ToString();
        CriticalText.text = "크리티컬 : " + character.Critical.ToString();
    }

    public void OnClickEquipButton()
    {
        if (selectedItem == null) return;

        var character = GameManager.Instance?.PlayerCharacter;

        bool isEquipped = IsItemEquipped(selectedItem);

        if (isEquipped)
        {
            character.UnequipItem(selectedItem);
            SetSlotEquippedState(selectedItem, false);
            equipButtonText.text = "장착";

            Debug.Log($"{selectedItem.displayName} 해제됨!");
        }
        else
        {
            character.EquipItem(selectedItem);
            SetSlotEquippedState(selectedItem, true);
            equipButtonText.text = "해제";
            Debug.Log($"{selectedItem.displayName} 장착됨!");
        }
        UpdateInventoryUI();
        ShowStatusInfo(selectedItem);
        DataSaveLoad.Instance.SaveInventory(slots);
    }

    private bool IsItemEquipped(ItemData item)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {

                return slot.equipped;
            }
                
        }
        return false;
    }

    private void SetSlotEquippedState(ItemData item, bool equipped)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.equipped = equipped;
                slot.Set(); // 슬롯 UI도 업데이트
                break;
            }
        }
    }

    public void ApplyLoadedInventory(InventorySaveData loadedData)
    {
        var character = GameManager.Instance?.PlayerCharacter;
        for (int i = 0; i < loadedData.inventory.Count && i < slots.Count; i++)
        {
            var saveItem = loadedData.inventory[i];
            ItemData item = Resources.Load<ItemData>("Items/" + saveItem.itemId);

            if (item != null)
            {
                InitSlot(slots[i], item, saveItem.quantity);
                slots[i].equipped = saveItem.isEquipped;
                slots[i].Set(); // UI 업데이트
            }
            if (saveItem.isEquipped)
            {
                character?.EquipItem(item);
            }
            else
            {
                Debug.LogWarning("아이템 불러오기 실패: " + saveItem.itemId);
            }
        }
        UpdateInventoryUI();
    }

}
