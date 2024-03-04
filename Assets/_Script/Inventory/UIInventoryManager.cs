using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryManager : PresistentSingleton<UIInventoryManager>
{

    [SerializeField] private Transform _inventory;
    [SerializeField] private KeyCode _openKey;
    [SerializeField] private bool _isOpening = false;
    [SerializeField] private CanvasGroup _inventoryCanvasGroup;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        _openKey = KeyCode.I;
        _inventory = transform.Find("IngameMenu").Find("Inventory");
        _inventoryCanvasGroup = _inventory.GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        SetInventoryUIVisible(0);
    }

    private void SetInventoryUIVisible(float visible)
    {
        _inventoryCanvasGroup.alpha = visible;
    }

    private void OnDisable()
    {
        CloseInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_openKey))
        {
            if(_isOpening)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }


    public void OpenInventory()
    {
        SetInventoryUIVisible(1);
        _inventory.GetComponentInChildren<UIInventoryPanel>().UpdateInventoryUI();
        _isOpening = true;
    }

    public void CloseInventory()
    {
        SetInventoryUIVisible(0);
        _isOpening = false;
    }

}
