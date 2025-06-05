using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character PlayerCharacter { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetData();
    }

    public void SetData()
    {
        PlayerCharacter = new Character("전사", "공룡", 1, 10, 1, "무시무시한 녀석입니다.", 10, 10, 100, 10);
        Debug.Log($"직업: {PlayerCharacter.Job}");
        Debug.Log($"플레이어 이름: {PlayerCharacter.CharacterName}");
        Debug.Log($"현재 경험치: {PlayerCharacter.CurrentExp}");
        Debug.Log($"최대 경험치: {PlayerCharacter.MaxExp}");
        Debug.Log($"레벨: {PlayerCharacter.Level}");
        Debug.Log($"설명: {PlayerCharacter.Explain}");
        Debug.Log($"공격력: {PlayerCharacter.Attack}");
        Debug.Log($"방어력: {PlayerCharacter.Defense}");
        Debug.Log($"체력: {PlayerCharacter.Hp}");
        Debug.Log($"크리티컬: {PlayerCharacter.Critical}");
    }
}
