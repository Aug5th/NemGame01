using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceSystem : Singleton<ResourceSystem>
{
    [Header("Enemy Resources")]
    [SerializeField] private List<EnemyScriptableObject> enemies;
    public List<EnemyScriptableObject> Enemies => enemies;
    private Dictionary<EnemyType, EnemyScriptableObject> EnemiesDict;

    [Header("Projectile Resources")]
    [SerializeField] private List<ProjectileScriptableObject> projectiles;
    public List<ProjectileScriptableObject> Projectiles => projectiles;
    private Dictionary<ProjectileType, ProjectileScriptableObject> ProjectilesDict;

    [Header("Floating Text Resources")]
    [SerializeField] private List<FloatingTextScriptableObject> floatingTexts;
    public List<FloatingTextScriptableObject> FloatingTexts => floatingTexts;

    [Header("ItemResources")]
    [SerializeField] private List<ItemScriptableObject> items;
    public List<ItemScriptableObject> Items => items;
    private Dictionary<ItemCode, ItemScriptableObject> ItemsDict;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        AssembleResources();
    }

    private void AssembleResources()
    {
        LoadEnemies();
        LoadProjectile();
        LoadFloatingText();
        LoadItems();
    }

    private void LoadItems()
    {
        items = Resources.LoadAll<ItemScriptableObject>("Items").ToList();
        ItemsDict = items.ToDictionary(r => r.ItemCode, r => r);
    }

    private void LoadFloatingText()
    {
        floatingTexts = Resources.LoadAll<FloatingTextScriptableObject>("FloatingTexts").ToList();
    }

    private void LoadEnemies()
    {
        enemies = Resources.LoadAll<EnemyScriptableObject>("Enemies").ToList();
        EnemiesDict = enemies.ToDictionary(r => r.enemyType, r => r);
    }

    private void LoadProjectile()
    {
        projectiles = Resources.LoadAll<ProjectileScriptableObject>("Projectiles").ToList();
        ProjectilesDict = projectiles.ToDictionary(r => r.projectileType, r => r);
    }

    public EnemyScriptableObject GetEnemy(EnemyType t) => EnemiesDict[t];
    public ProjectileScriptableObject GetProjectile(ProjectileType t) => ProjectilesDict[t];
    public FloatingTextScriptableObject GetFloatingText() => FloatingTexts[0];
    public ItemScriptableObject GetItem(ItemCode c) => ItemsDict[c];
}

