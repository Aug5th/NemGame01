using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MyMonoBehaviour
{
    [SerializeField] private Transform _itemSprite;
    [SerializeField] private Transform _itemQuantity;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        _itemSprite = transform.Find("ItemSprite");
        _itemQuantity = transform.Find("ItemQuantity");
    }

    public void SetVisibleItem(bool isVisible)
    {
        _itemSprite.gameObject.SetActive(isVisible);
        _itemQuantity.gameObject.SetActive(isVisible);
    }

    public void LoadItem(InventoryItem item)
    {
        SetVisibleItem(true);
        var quantity = item.Quantity.ToString();
        _itemSprite.GetComponent<Image>().sprite = item.ItemIcon;
        _itemQuantity.GetComponent<TextMeshProUGUI>().text = quantity;
    }
}
