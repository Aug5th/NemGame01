using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item Object")]
public class ItemScriptableObject : ScriptableObject
{
    public ItemType ItemType;
    public ItemCode ItemCode;
    public Item Prefab;
    [SerializeField]
    private ItemStats _stats;
    public ItemStats BaseStats => _stats;
}


[Serializable]
public struct ItemStats
{
    public float DropChance;
    public float Weight; 
}


[Serializable]
public enum ItemType
{
    None,
    Consumable,
    Quest,
    Material,
    Equipment
}

[Serializable]
public enum ItemCode
{
    None = 0,
    Slime = 1,
    Gold = 2,
}