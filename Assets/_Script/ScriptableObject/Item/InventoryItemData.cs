using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "ScriptableObject/Item Data")]
public class InventoryItemData : ScriptableObject
{
    public ItemCode ItemCode;
    public ItemType ItemType;
    public Sprite ItemIcon;
    [TextArea(4, 4)] public string Description;
    public int MaxStackSize;
}
