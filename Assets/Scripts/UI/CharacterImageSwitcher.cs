using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterImageSwitcher : MonoBehaviour
{
    public Sprite[] characterSprites; // 캐릭터 이미지 배열
    public Image characterImage;      // 표시할 UI Image
    private int currentIndex = 0;
    public UIStartMenu uiStartMenu;

    

    private void Start()
    {
        if (characterSprites.Length > 0)
        {
            // 초기 이미지 설정
            characterImage.sprite = characterSprites[currentIndex];

            // 공룡 캐릭터 설명 표시
            Character defaultCharacter = GameManager.Instance.characterList[currentIndex];
            GameManager.Instance.SelectCharacter(currentIndex); // GameManager에 선택 반영
            uiStartMenu.ShowCharacterExplain(defaultCharacter);
        }
    }

    public void ShowNextImage()
    {
        if (characterSprites.Length == 0) return;

        currentIndex = (currentIndex + 1) % characterSprites.Length;
        characterImage.sprite = characterSprites[currentIndex];

        Character selectedCharacter = GameManager.Instance.characterList[currentIndex];
        uiStartMenu.ShowCharacterExplain(selectedCharacter);
    }

    public void ShowPreviousImage()
    {
        if (characterSprites.Length == 0) return;

        currentIndex = (currentIndex - 1 + characterSprites.Length) % characterSprites.Length;
        characterImage.sprite = characterSprites[currentIndex];

        Character selectedCharacter = GameManager.Instance.characterList[currentIndex];
        uiStartMenu.ShowCharacterExplain(selectedCharacter);
    }

    public void SelectCurrentCharacter()
    {
        Character selectedCharacter = GameManager.Instance.characterList[currentIndex];
        GameManager.Instance.SelectCharacter(currentIndex);

        uiStartMenu.ShowCharacterExplain(selectedCharacter);
        DataSaveLoad.Instance.SaveCharacterData(selectedCharacter); // 저장 실행
        SceneManager.LoadScene("MainScene"); // 게임 씬으로 전환
        
    }
}
