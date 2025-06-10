using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string Job;
    public string CharacterName;
    public int CurrentExp;
    public int MaxExp;
    public int Level;
    public string Explain;

    public float Attack;
    public float Defense;
    public float Hp;
    public float Critical;

    // 필요한 경우 Inventory도 public 필드로 선언
    public List<ItemData> Inventory = new List<ItemData>();

    private List<ItemData> equippedItems = new List<ItemData>();

    public Character(string job, string name, int currentExp, int maxExp, int level, string explain,
        int attack, int defense, int hp, int critical, List<ItemData> initialInventory = null)
    {
        Job = job;
        CharacterName = name;
        CurrentExp = currentExp;
        MaxExp = maxExp;
        Level = level;
        Explain = explain;
        Attack = attack;
        Defense = defense;
        Hp = hp;
        Critical = critical;

        if (initialInventory != null)
            Inventory = new List<ItemData>(initialInventory);
    }

    public void AddItem(ItemData item)
    {
        if (item != null)
            Inventory.Add(item);
    }

    public void EquipItem(ItemData item)
    {
        if (item == null || item.equipableData == null || IsEquipped(item))
            return;

        switch (item.equipableData.type)
        {
            case EquipableType.Attack:
                Attack += item.equipableData.value;
                break;
            case EquipableType.Defense:
                Defense += item.equipableData.value;
                break;
            case EquipableType.Hp:
                Hp += item.equipableData.value;
                break;
            case EquipableType.Critical:
                Critical += item.equipableData.value;
                break;
        }

        equippedItems.Add(item);
    }
    public void UnequipItem(ItemData item)
    {
        if (item == null || item.equipableData == null || !IsEquipped(item))
            return;

        switch (item.equipableData.type)
        {
            case EquipableType.Attack:
                Attack -= item.equipableData.value;
                break;
            case EquipableType.Defense:
                Defense -= item.equipableData.value;
                break;
            case EquipableType.Hp:
                Hp -= item.equipableData.value;
                break;
            case EquipableType.Critical:
                Critical -= item.equipableData.value;
                break;
        }

        equippedItems.Remove(item);
    }
    public bool IsEquipped(ItemData item)
    {
        return equippedItems.Contains(item);
    }
}