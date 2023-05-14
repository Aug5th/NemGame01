using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Enemy" , menuName ="ScriptableObject/Enemy Object")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType enemyType;
    [SerializeField]
    private EnemyStats _stats;
    public EnemyStats BaseStats => _stats;

    public EnemyBase Prefab;

}

[Serializable]
public struct EnemyStats
{
    public float Health;
    public float AttackPower;
    public float AttackRange;
    public float MovementSpeed;
}

[Serializable]
public enum EnemyType
{
    Slime = 0,
    FireSlime = 1,
    KingSlime = 2,
}

