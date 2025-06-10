using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStartMenu : MonoBehaviour
{
    [Header("UIStartMenu - 연결 요소들")]
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI crrentExtText;
    [SerializeField] private TextMeshProUGUI maxExpText;
    [SerializeField] private TextMeshProUGUI explainText;

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
