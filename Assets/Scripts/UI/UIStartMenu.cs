using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenu : MonoBehaviour
{
    [Header("UIStartMenu - 연결 요소들")]
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI crrentExtText;
    [SerializeField] private TextMeshProUGUI maxExpText;
    [SerializeField] private TextMeshProUGUI explainText;

    private void Start()
    {
        Character loadedCharacter = FindObjectOfType<DataSaveLoad>()?.LoadCharacterData();

        if (loadedCharacter != null)
        {
            // 바로 MainScene으로 씬 전환
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.LogWarning("캐릭터 데이터를 불러오지 못했습니다.");
            // 데이터 없으면 여기서 UI를 보여주거나 다른 행동을 할 수 있음
        }
    }
    public void ShowCharacterExplain(Character player)
    {
        jobText.text = $"직업 :  {player.Job}";
        nameText.text = $"이름 : {player.CharacterName}";
        levelText.text = $"레벨 : {player.Level}";
        crrentExtText.text = player.CurrentExp.ToString() + "/  ";
        maxExpText.text = player.MaxExp.ToString();
        explainText.text = player.Explain;
    }
}
