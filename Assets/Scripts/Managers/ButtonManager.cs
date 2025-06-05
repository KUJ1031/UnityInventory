using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OpenStatus()
    {
        UIManager.Instance.UIStatus.SetActive(true);
    }
    public void OpenInventory()
    {
        UIManager.Instance.UIInventory.SetActive(true);
    }
    public void CloseStatus()
    {
        UIManager.Instance.UIStatus.SetActive(false);
    }
    public void CloseInventory()
    {
        UIManager.Instance.UIInventory.SetActive(false);
    }
}
