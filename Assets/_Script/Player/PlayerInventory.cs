using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MyMonoBehaviour
{
    [SerializeField] private List<InventoryItem> _inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collectable = collision.GetComponent<ICollectable>();
        if (collectable == null)
        {
            return;
        }
        var item = collectable.Collect();
        AddItem(item);
    }
    public List<InventoryItem> GetInventory()
    {
        return _inventory;
    }
    public void AddItem(InventoryItem item)
    {
        InventoryItem existingItem = _inventory.Find(i => i.ItemCode == item.ItemCode);

        if(existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            _inventory.Add(item);
        }
    }
    public void RemoveItem(InventoryItem item)
    {
        _inventory.Remove(item);
    }
}
