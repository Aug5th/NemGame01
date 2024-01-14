using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPanel : MyMonoBehaviour
{

    [SerializeField] RectTransform _inventoryContent;

    [SerializeField] UIInventoryItem _inventoryPrefab;

    [SerializeField] List<UIInventoryItem> _inventoryItems = new List<UIInventoryItem>();


    protected override void LoadComponents()
    {
        base.LoadComponents();
        //_inventoryContent = transform.Find("Content").GetComponent<RectTransform>();
    }

    private void Start()
    {
        InitInventoryUI(80);
    }

    public void InitInventoryUI(int size)
    {
        for (int i = 0; i < size; i++)
        {
            UIInventoryItem uiItem = Instantiate(_inventoryPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(_inventoryContent);
            uiItem.transform.localScale = Vector3.one;
            _inventoryItems.Add(uiItem);
        }
    }
}
