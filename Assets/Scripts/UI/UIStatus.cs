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

    private void Start()
    {
        Character player = GameManager.Instance.PlayerCharacter;

        attackText.text = $"공격력 : {player.Attack}";
        deffenseText.text = $"방어력 : {player.Defense}";
        hpText.text = $"체력 : {player.Hp}";
        criticalText.text = $"치명타 : {player.Critical}";
    }

}
