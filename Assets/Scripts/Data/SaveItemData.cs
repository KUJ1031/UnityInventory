using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [Serializable]
    public class SaveItemData
    {
        public string itemId;     // ScriptableObject의 고유 ID
        public int quantity;      // 수량
        public bool isEquipped;   // 장착 여부
    }

    [System.Serializable]
    public class InventorySaveData
    {
        public List<SaveItemData> inventory = new List<SaveItemData>(); // 초기화 필수!
    }
}
