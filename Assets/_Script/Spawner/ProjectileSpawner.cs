using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileSpawner : Singleton<ProjectileSpawner>
{
    private ObjectPool<ProjectileBase> arrowPool;
    private ObjectPool<ProjectileBase> fireballPool;
    [SerializeField]
    private Transform _holder;

    protected override void LoadComponents()
    {
        LoadHolder();
        base.LoadComponents();
    }

    private void LoadHolder()
    {
        if (_holder != null)
            return;
        _holder = transform.Find("Holder");
    }

    private void Start()
    {
        InitArrowPool();
        InitFireballPool();
    }

    private void InitArrowPool()
    {
        arrowPool = new ObjectPool<ProjectileBase>(() =>
        {
            var projectile = ResourceSystem.Instance.GetProjectile(ProjectileType.Arrow);
            var prefab = projectile.Prefab;
            return Instantiate(prefab);
        }, projectile =>
        {
            projectile.gameObject.SetActive(true);
        }, projectile =>
        {
            projectile.gameObject.SetActive(false);
        }, projectile =>
        {
            Destroy(projectile.gameObject);
        }, false, 10, 20);
    }
    private void InitFireballPool()
    {
        fireballPool = new ObjectPool<ProjectileBase>(() =>
        {
            var projectile = ResourceSystem.Instance.GetProjectile(ProjectileType.Fireball);
            var prefab = projectile.Prefab;
            return Instantiate(prefab);
        }, projectile =>
        {
            projectile.gameObject.SetActive(true);
        }, projectile =>
        {
            projectile.gameObject.SetActive(false);
        }, projectile =>
        {
            Destroy(projectile.gameObject);
        }, false, 10, 20);
    }

    private ProjectileBase GetProjectilePool(ProjectileType type)
    {
        ProjectileBase projectile = null;
        switch (type)
        {
            case ProjectileType.Arrow:
                projectile =  arrowPool.Get();
                break;
            case ProjectileType.Fireball:
                projectile =  fireballPool.Get();
                break;
            case ProjectileType.Snowball:
                break;
        }
        return projectile;
    }

    public virtual ProjectileBase SpawnProjectile(ProjectileType type)
    {
        var projectile = GetProjectilePool(type);
        var baseStats = ResourceSystem.Instance.GetProjectile(type).BaseStats;
        projectile.SetStats(baseStats);
        projectile.transform.SetParent(_holder);
        SetPool(projectile, type);
        return projectile;
    }

    public virtual void SetPool(ProjectileBase projectile,ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.Arrow:
                projectile.SetPool(arrowPool);
                break;
            case ProjectileType.Fireball:
                projectile.SetPool(fireballPool);
                break;
            case ProjectileType.Snowball:
                break;
            default:
                break;
        }
    }


}


