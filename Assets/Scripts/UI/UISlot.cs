using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData item;

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;

    public UIInventory inventory;

    public int index;
    public bool equipped;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        var character = GameManager.Instance.PlayerCharacter;

        if (equipped)
        {
            character.UnequipItem(item);
            equipped = false;
            outline.enabled = false;
            Debug.Log($"{item.displayName} 해제됨!");
        }
        else
        {
            character.EquipItem(item);
            equipped = true;
            outline.enabled = true;
            Debug.Log($"{item.displayName} 장착됨!");
        }

        inventory.UpdateInventoryUI(); // 인벤토리 갱신 (총 장착 아이템 수 등)
        inventory.ShowItemInfo(item);
        Debug.Log($"공격력: {character.Attack}, 방어력: {character.Defense}");
        
    }
}
