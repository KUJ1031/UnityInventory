using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI deffenseText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private void OnEnable()
    {
        Character player = GameManager.Instance?.PlayerCharacter;

        if (player != null)
        {
            attackText.text = $"공격력 : {player.Attack} ( +{player.GetAddStatus(EquipableType.Attack)} )";
            deffenseText.text = $"방어력 : {player.Defense} ( +{player.GetAddStatus(EquipableType.Defense)} )";
            hpText.text = $"체력 : {player.Hp} ( +{player.GetAddStatus(EquipableType.Hp)} )";
            criticalText.text = $"크리티컬 : {player.Critical} ( +{player.GetAddStatus(EquipableType.Critical)} )";
        }
        else
        {
            Debug.LogWarning("캐릭터 데이터를 불러올 수 없습니다.");
        }
    }

}
