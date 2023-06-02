using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MyMonoBehaviour 
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    private ObjectPool<EnemyBase> slimePool;
    private ObjectPool<EnemyBase> kingSlimePool;
    [SerializeField]
    private List<Transform> slimeNestSpawnPoints;
    [SerializeField]
    private Transform holder;


    protected override void LoadComponents()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("ProjectileSpawner is existing");
        LoadHolder();
        LoadSpawnPoints();
        base.LoadComponents();
    }

    private void LoadHolder()
    {
        if (holder != null)
            return;
        holder = transform.Find("Holder");
    }

    private void LoadSpawnPoints()
    {
        LoadSlimeNestSpawnPoint();
    }

    private void LoadSlimeNestSpawnPoint()
    {
        if (slimeNestSpawnPoints.Count > 0)
            return;
        Transform spawnPoints = transform.Find("SlimeNest");
        if (spawnPoints != null)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                slimeNestSpawnPoints.Add(spawnPoint);
            }
        }
    }

    private void Start()
    { 
        InitSlimePool();
        InitKingSlimePool();
        SpawnSlimeNest();
    }

    private void SpawnSlimeNest()
    {
        foreach (var spawnPoint in slimeNestSpawnPoints)
        {
            EnemyType enemyType = EnemyType.Slime;
            if (spawnPoint.name == "KingSlimeSpawnPoint")
                enemyType = EnemyType.KingSlime;

            //var slime = enemySpawner.Spawn(enemyType, spawnPoint.position, spawnPoint.rotation);
            var slime = SpawnEnemy(enemyType);
            slime.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void InitSlimePool()
    {
        slimePool = new ObjectPool<EnemyBase>(() =>
        {
            var enemy = ResourceSystem.Instance.GetEnemy(EnemyType.Slime);
            var prefab = enemy.Prefab;
            return Instantiate(prefab);
        }, enemy =>
        {
            enemy.gameObject.SetActive(true);
        }, enemy =>
        {
            enemy.gameObject.SetActive(false);
        }, enemy =>
        {
            Destroy(enemy.gameObject);
        }, false, 10, 20);
    }
    private void InitKingSlimePool()
    {
        kingSlimePool = new ObjectPool<EnemyBase>(() =>
        {
            var enemy = ResourceSystem.Instance.GetEnemy(EnemyType.KingSlime);
            var prefab = enemy.Prefab;
            return Instantiate(prefab);
        }, enemy =>
        {
            enemy.gameObject.SetActive(true);
        }, enemy =>
        {
            enemy.gameObject.SetActive(false);
        }, enemy =>
        {
            Destroy(enemy.gameObject);
        }, false, 10, 20);
    }

    private EnemyBase GetEnemyPool(EnemyType type)
    {
        EnemyBase enemy = null;
        switch (type)
        {
            case EnemyType.Slime:
                enemy = slimePool.Get();
                break;
            case EnemyType.FireSlime:
                enemy = slimePool.Get();
                break;
            case EnemyType.KingSlime:
                enemy = kingSlimePool.Get();
                break;
        }
        return enemy;
    }

    public virtual EnemyBase SpawnEnemy(EnemyType type)
    {
        var enemy = GetEnemyPool(type);
        var baseStats = ResourceSystem.Instance.GetEnemy(type).BaseStats;
        enemy.SetStats(baseStats);
        enemy.transform.SetParent(holder);
        SetPool(enemy, type);
        Debug.Log(enemy.Stats.Health);
        return enemy;
    }

    public virtual void SetPool(EnemyBase enemy, EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Slime:
                enemy.SetPool(slimePool);
                break;
            case EnemyType.FireSlime:
                break;
            case EnemyType.KingSlime:
                enemy.SetPool(kingSlimePool);
                break;
            default:
                break;
        }
    }

}
