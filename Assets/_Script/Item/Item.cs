using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MyMonoBehaviour , ICollectable
{
    [SerializeField] public ItemStats Stats { get; private set; }
    public void SetStats(ItemStats stats) => Stats = stats;

    [SerializeField] private InventoryItem _inventoryItem;

    private ObjectPool<Item> _pool;
    public InventoryItem Collect()
    {
        Destroy(gameObject);
        return _inventoryItem;
    }
    public void SetPool(ObjectPool<Item> pool)
    {
        _pool = pool;
    }
    public void ReleaseItem()
    {
        _pool.Release(this);
    }
    public void SetInventoryItem(ItemStructure item)
    {
        var itemScript = ResourceSystem.Instance.GetItem(item.ItemCode);
        _inventoryItem = new InventoryItem(item.ItemCode, itemScript.ItemType, itemScript.itemIcon, item.Quantity);
    }
}

[Serializable]
public struct ItemStructure
{
    public ItemCode ItemCode;
    public int Quantity;
}
