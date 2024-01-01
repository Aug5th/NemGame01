using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemSpawner : Singleton<ItemSpawner>
{
    private ObjectPool<Item> _itemPool;

    private Dictionary<ItemCode, ItemScriptableObject> _itemsDictionary;

    private Dictionary<ItemCode, ObjectPool<Item>> _itemPools;

    private Dictionary<ItemCode, float> _itemDropRateList;
    public Dictionary<ItemCode, float> ItemDropRateList => _itemDropRateList;

    private ItemCode _itemCode;

    [SerializeField]
    private Transform _holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHolder();
    }

    private void Start()
    {
        _itemsDictionary = ResourceSystem.Instance.ItemsDict;
        _itemPools = new();
        _itemDropRateList = new();
        InitItemPool();
    }

    private void LoadHolder()
    {
        if (_holder != null)
            return;
        _holder = transform.Find("Holder");
    }

    private void InitItemPool()
    {
        foreach (var item in _itemsDictionary)
        {
            _itemCode = item.Key;
            var itemScript = item.Value;
            ObjectPool<Item> newObjectPool = new ObjectPool<Item>(() =>
            {
                var prefab = itemScript.Prefab;
                return Instantiate(prefab);
            }, item =>
            {
                item.gameObject.SetActive(true);
            }, item =>
            {
                item.gameObject.SetActive(false);
            }, item =>
            {
                Destroy(item.gameObject);
            }, false, 10, 20);

            if(newObjectPool == null || _itemPools == null)
            {
                Debug.Log("NULL");
            }
            else
            {
                _itemDropRateList.Add(_itemCode, itemScript.BaseStats.DropChance);
                _itemPools.Add(_itemCode, newObjectPool);
            }
        }
    }

    private Item GetItem(ItemCode itemCode)
    {
        return _itemPools[itemCode].Get();
    }

    public Item SpawnItem(ItemCode itemCode)
    {
        var item = GetItem(itemCode);
        var itemScript = _itemsDictionary[itemCode];
        item.SetStats(itemScript.BaseStats);
        item.SetPool(_itemPools[itemCode]);
        item.transform.SetParent(_holder);

        return item;
    }

    private Item CreateItem()
    {
        var itemScript = ResourceSystem.Instance.GetItem(_itemCode);
        Item item = Instantiate(itemScript.Prefab);
        return item;
    }

    private void OnTakeItemFromPool(Item item)
    {

    }

    private void OnReturnItemToPool(Item item)
    {

    }

    private void OnDestroyItem(Item item)
    {

    }
}
