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

    private Transform _impactPosition;
    public ProjectileStats Stats { get; private set; }
    public virtual void SetStats(ProjectileStats stats) => Stats = stats;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        _impactPosition = transform.Find("ImpactPosition");
    }

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
            //Debug.Log("DespawnProjectile by range");
            pool.Release(this);
        }
    }

    public virtual void SendDamage()
    {
        //send ItemStats.damage
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Item") || collision.CompareTag("Collider"))
        {
            return;
        }

        var damageable = collision.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.ApplyDamage(Stats.damage);
        }
        
        pool.Release(this);

        var knockbackable = collision.GetComponent<IKnockbackable>();
        if(knockbackable != null)
        {
            knockbackable.StartKnockback(_impactPosition, 3f);
        }

    }

    public void SetPool(ObjectPool<ProjectileBase> pool)
    {
        this.pool = pool;
    }

}
