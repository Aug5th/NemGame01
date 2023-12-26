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
    private Stats _stats;
    public Stats Stats => _stats;
}


[Serializable]
public struct Stats
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
    Slime = 1
}