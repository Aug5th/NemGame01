using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "ScriptableObject/Projectile Object")]
public class ProjectileScriptableObject : ScriptableObject
{
    public ProjectileType projectileType;
    [SerializeField]
    private ProjectileStats _stats;
    public ProjectileStats BaseStats => _stats;

    public ProjectileBase Prefab;
}

[Serializable]
public struct ProjectileStats
{
    public float damage;
    public float speed;
    public float attackDistance;
    public float attackRate;
    public float maxDistance;
}

[Serializable]
public enum ProjectileType
{
    Arrow = 0,
    Fireball = 1,
    Snowball = 2,
}

