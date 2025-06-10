using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character PlayerCharacter { get; private set; }
    public List<Character> characterList = new List<Character>();
    public Character SelectedCharacter { get; private set; }
    public DataSaveLoad dataSaveLoad; // 인스펙터에 연결

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerCharacter = FindObjectOfType<DataSaveLoad>()?.LoadCharacterData();
        SetData();
    }

    public void SetData()
    {
        characterList.Add(new Character("전사", "공룡", 1, 10, 1, "무시무시한 녀석입니다.\n맘에 안 들면 몸통박치기를 시전해버립니다.", 10, 10, 100, 10));
        characterList.Add(new Character("악마", "데빌", 1, 8, 1, "지옥에서 온 사신입니다.\n바나나 우유를 굉장히 좋아합니다.", 12, 8, 80, 20));
        characterList.Add(new Character("기사", "기사", 1, 12, 1, "명예로운 기사입니다.\n자신의 꿈을 쫓아 이름도 바꿔버렸습니다.", 9, 12, 90, 15));

        // 기본 선택값 설정 (예: 공룡)
        SelectedCharacter = characterList[0];
        DebugCharacter(SelectedCharacter);
    }

    public void SelectCharacter(int index)
    {
        if (index >= 0 && index < characterList.Count)
        {
            SelectedCharacter = characterList[index];
            DebugCharacter(SelectedCharacter);
        }
    }

    private void DebugCharacter(Character character)
    {
        Debug.Log($"직업: {character.Job}");
        Debug.Log($"플레이어 이름: {character.CharacterName}");
        Debug.Log($"레벨: {character.Level}");
        Debug.Log($"현재 경험치: {character.CurrentExp}");
        Debug.Log($"최대 경험치: {character.MaxExp}");
        Debug.Log($"설명: {character.Explain}");
        Debug.Log($"공격력: {character.Attack}");
        Debug.Log($"방어력: {character.Defense}");
        Debug.Log($"체력: {character.Hp}");
        Debug.Log($"크리티컬: {character.Critical}");
    }
}
