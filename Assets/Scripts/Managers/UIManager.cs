using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("설정")]
    [SerializeField] private GameObject uiStatus;
    public GameObject UIStatus
    {
        get => uiStatus;
       // set => uiStatus = value;
    }

    [SerializeField] private GameObject uiInventory;
    public GameObject UIInventory
    {
        get => uiInventory;
        set => uiInventory = value;
    }

    [SerializeField] private GameObject uiMainmenu;
    public GameObject UIMainmenu
    {
        get => uiMainmenu;
        set => uiMainmenu = value;
    }

    public static UIManager Instance { get; set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
          //  DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
