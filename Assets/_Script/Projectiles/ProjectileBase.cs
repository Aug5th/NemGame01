using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileBase : MyMonoBehaviour
{
    [SerializeField]
    private float distance;

    private ObjectPool<ProjectileBase> pool;
    public ProjectileStats Stats { get; private set; }
    public virtual void SetStats(ProjectileStats stats) => Stats = stats;

    private void FixedUpdate()
    {
        DespawnProjectile();
    }

    private void DespawnProjectile()
    {
        var mainCamera = GameManager.Instance.MainCamera;
        distance = Vector2.Distance(transform.position, mainCamera.transform.position);
        if (distance >= Stats.maxDistance)
        {
            Debug.Log("DespawnProjectile by range");
            pool.Release(this);
        }
    }

    public virtual void SendDamage()
    {
        //send Stats.damage
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            pool.Release(this);
            Debug.Log("Send Damage : " + Stats.damage);
            collision.GetComponent<IDamageable>().ApplyDamage(Stats.damage);
        }
    }

    public void SetPool(ObjectPool<ProjectileBase> pool)
    {
        this.pool = pool;
    }

}
