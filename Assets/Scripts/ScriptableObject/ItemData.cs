using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable
}

public enum EquipableType
{
    Attack,
    Defense,
    Hp,
    Critical
}

[System.Serializable]
public class ItemDataEquipable
{
    public EquipableType type;
    public float value;
}

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount = 1;

    [Header("Equip")]
    public GameObject equipPrefab;

    [Header("Equipable Stats")]
    public ItemDataEquipable equipableData;
}
