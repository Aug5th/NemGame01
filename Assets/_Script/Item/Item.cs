using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MyMonoBehaviour , ICollectable
{
    [SerializeField] public ItemStats Stats { get; private set; }
    public void SetStats(ItemStats stats) => Stats = stats;

    [SerializeField] private ItemStructure _itemStruct;

    private ObjectPool<Item> _pool;
    public ItemStructure Collect()
    {
        Destroy(gameObject);
        return _itemStruct;
    }
    public void SetPool(ObjectPool<Item> pool)
    {
        _pool = pool;
    }
    public void ReleaseItem()
    {
        _pool.Release(this);
    }
    public void SetItemStruct(ItemStructure itemStruct)
    {
        _itemStruct = itemStruct;
    }
}

[Serializable]
public struct ItemStructure
{
    public ItemCode ItemCode;
    public int Amount;
}
