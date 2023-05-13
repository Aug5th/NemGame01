using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MyMonoBehaviour
{
    [SerializeField]
    private List<Transform> slimeNestSpawnPoints;
    [SerializeField]
    private EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;
    protected override void LoadComponents()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        LoadSpawnPoints();
        base.LoadComponents();
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
        if(spawnPoints != null)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                slimeNestSpawnPoints.Add(spawnPoint);
            }
        }
    }
    private void SpawnSlimeNest()
    {
        foreach (var spawnPoint in slimeNestSpawnPoints)
        {
            string slimeType = EnemySpawner.Slime;
            if (spawnPoint.name == "KingSlimeSpawnPoint")
                slimeType = EnemySpawner.KingSlime;

            var slime = enemySpawner.Spawn(slimeType, spawnPoint.position, spawnPoint.rotation);
            slime.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        SpawnSlimeNest();
    }
}
