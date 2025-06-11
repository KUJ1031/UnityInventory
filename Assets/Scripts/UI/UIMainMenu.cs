using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [Header("UIMainMenu - 연결 요소들")]
    [SerializeField] private TextMeshProUGUI jobText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI crrentExtText;
    [SerializeField] private TextMeshProUGUI maxExpText;
    [SerializeField] private TextMeshProUGUI explainText;

    [SerializeField] private UnityEngine.UI.Image characterImage;
    [SerializeField] private Sprite warriorSprite;
    [SerializeField] private Sprite devilSprite;
    [SerializeField] private Sprite knightSprite;

    private void Start()
    {
        Character loadedCharacter = FindObjectOfType<DataSaveLoad>()?.LoadCharacterData();

        if (loadedCharacter != null)
        {
            UpdateUI(loadedCharacter);
        }
        else
        {
            Debug.LogWarning("캐릭터 데이터를 불러오지 못했습니다.");
        }
    }

    private void UpdateUI(Character player)
    {
        jobText.text = $"직업 :  {player.Job}";
        nameText.text = $"이름 : {player.CharacterName}";
        levelText.text = $"레벨 : {player.Level}";
        crrentExtText.text = player.CurrentExp.ToString() + "/";
        maxExpText.text = player.MaxExp.ToString();
        explainText.text = player.Explain;

        switch (player.Job)
        {
            case "전사":
                characterImage.sprite = warriorSprite;
                break;
            case "악마":
                characterImage.sprite = devilSprite;
                break;
            case "기사":
                characterImage.sprite = knightSprite;
                break;
            default:
                Debug.LogWarning("알 수 없는 직업: " + player.Job);
                break;
        }
    }
}
