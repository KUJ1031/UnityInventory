using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static SaveData;

public class DataSaveLoad : MonoBehaviour
{
    public static DataSaveLoad Instance { get; private set; }
    private string filePath;

    private string inventoryPath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        filePath = Path.Combine(Application.persistentDataPath, "characterData.json");
        inventoryPath = Path.Combine(Application.persistentDataPath, "inventoryData.json");
        Debug.Log("DataSaveLoad Awake 실행됨. 경로: " + filePath);
    }

    // 저장
    public void SaveCharacterData(Character character)
    {
        string json = JsonUtility.ToJson(character, true);
        File.WriteAllText(filePath, json);
        Debug.Log("저장 경로: " + Application.persistentDataPath);
        Debug.Log("캐릭터 데이터 저장 완료:\n" + json);
    }

    public void SaveInventory(List<UISlot> slots)
    {
        InventorySaveData saveData = new InventorySaveData();

        foreach (var slot in slots)
        {
            if (slot.item == null) continue;

            saveData.inventory.Add(new SaveItemData
            {
                itemId = slot.item.itemId,
                quantity = slot.quantity,
                isEquipped = slot.equipped
            });
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(inventoryPath, json);
        Debug.Log("인벤토리 저장 완료\n" + json);
    }

    // 불러오기
    public Character LoadCharacterData()
    {
        Debug.Log("불러오기 시도 경로: " + filePath); // ← 경로 디버깅 추가
        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);
            Character loadedCharacter = JsonUtility.FromJson<Character>(json);
            Debug.Log("이미 생성된 캐릭터 데이터 불러오기 완료:\n" + json);
            return loadedCharacter;
        }
        else
        {
            Debug.LogWarning("저장된 캐릭터 데이터가 없습니다.");
            return null;
        }
    }
    public InventorySaveData LoadInventory()
    {
        if (!File.Exists(inventoryPath))
        {
            Debug.LogWarning("저장된 인벤토리 없음");
            return null;
        }

        string json = File.ReadAllText(inventoryPath);
        InventorySaveData data = JsonUtility.FromJson<InventorySaveData>(json);
        return data;
    }

    public void DeleteSavedJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "characterData.json");

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("저장된 JSON 파일을 삭제했습니다.");
        }
        else
        {
            Debug.LogWarning("삭제할 JSON 파일이 존재하지 않습니다.");
        }
    }
}
