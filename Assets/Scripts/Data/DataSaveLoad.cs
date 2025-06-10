using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaveLoad : MonoBehaviour
{
    public static DataSaveLoad Instance { get; private set; }
    private string filePath;

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

    // 불러오기
    public Character LoadCharacterData()
    {
        Debug.Log("불러오기 시도 경로: " + filePath); // ← 경로 디버깅 추가
        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);
            Character loadedCharacter = JsonUtility.FromJson<Character>(json);
            Debug.Log("캐릭터 데이터 불러오기 완료:\n" + json);
            return loadedCharacter;
        }
        else
        {
            Debug.LogWarning("저장된 캐릭터 데이터가 없습니다.");
            return null;
        }
    }
}
