using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MyMonoBehaviour , ICollectable
{
    [SerializeField] public ItemStats Stats { get; private set; }
    public void SetStats(ItemStats stats) => Stats = stats;

    private ObjectPool<Item> _pool;
    public void Collect()
    {
        Destroy(gameObject);
    }
    public void SetPool(ObjectPool<Item> pool)
    {
        _pool = pool;
    }

    public void ReleaseItem()
    {
        _pool.Release(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
