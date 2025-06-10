using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData item;

    public TextMeshProUGUI quantityText;
    private Outline outline;

    public UIInventory inventory;

    public GameObject equipImage;
    private ItemData currentEquippedItem;

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
       // quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
        if (outline != null)
        {
            outline.enabled = equipped;
        }
        equipImage?.gameObject.SetActive(equipped);
    }

    public void Clear()
    {
        item = null;
        quantityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        inventory.selectedItem = item; // 어떤 아이템을 선택했는지 저장
        inventory.ShowItemInfo(item);

    }
}
