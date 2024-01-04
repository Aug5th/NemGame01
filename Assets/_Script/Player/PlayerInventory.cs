using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MyMonoBehaviour
{
    [SerializeField] private List<ItemStructure> inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collectable = collision.GetComponent<ICollectable>();
        if (collectable == null)
        {
            return;
        }
        var item = collectable.Collect();
        UpdateInventory(item);
    }

    private void UpdateInventory(ItemStructure item)
    {
        // Update item amount if exists
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ItemCode.Equals(item.ItemCode))
            {
                ItemStructure newItem = inventory[i];
                newItem.Amount += item.Amount;
                inventory[i] = newItem;
                return;
            }  
        }
        // Add new item
        inventory.Add(item);
    }
}
