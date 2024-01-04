using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemCode ItemCode;
    public ItemType ItemType;
    public Sprite ItemIcon;
    public int Quantity;

    public InventoryItem(ItemCode itemCode, ItemType itemType, Sprite itemIcon, int quantity)
    {
        this.ItemCode = itemCode;
        this.ItemType = itemType;
        this.ItemIcon = itemIcon;
        this.Quantity = quantity;
    }
}
