using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Job { get; private set; }
    public string CharacterName { get; private set; }
    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }
    public int Level { get; private set; }
    public string Explain { get; private set; }
    public float Attack { get; private set; }
    public float Defense { get; private set; }
    public float Hp { get; private set; }
    public float Critical { get; private set; }

    public Character(string job, string name, int currentExp, int maxExp, int level, string explain, int attack, int defense, int hp, int critical)
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
    }

    public void EquipItem(ItemData item)
    {
        if (item == null || item.equipableData == null) return;

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
    }

    public void UnequipItem(ItemData item)
    {
        if (item == null || item.equipableData == null) return;

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
    }
}
