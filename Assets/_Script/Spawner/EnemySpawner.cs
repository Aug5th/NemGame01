using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner 
{
    private static readonly string slime = "Slime";
    public static string Slime { get => slime; }

    private static readonly string kingSlime = "KingSlime";
    public static string KingSlime { get => kingSlime; }


    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override Transform GetPrefab(int prefabType)
    {
        return ResourceSystem.Instance.GetEnemy((EnemyType)prefabType).Prefab.transform;
    }
}
