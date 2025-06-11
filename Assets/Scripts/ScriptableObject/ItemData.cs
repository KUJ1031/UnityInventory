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
    [Header("식별자")]
    public string itemId;  // 저장/불러오기용 ID (예: "sword_001")

    [Header("기본 정보")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;

    [Header("스택 관련")]
    public bool canStack;
    public int maxStackAmount = 1;

    [Header("장비 능력치")]
    public ItemDataEquipable equipableData;
}
