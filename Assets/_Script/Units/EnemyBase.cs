using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBase : MyMonoBehaviour , IDamageable
{
    private ObjectPool<EnemyBase> pool;
    public EnemyStats Stats { get; private set; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    public virtual void SetStats(EnemyStats stats)
    {
        Stats = stats;
        currentHealth = Stats.Health;
    }
    [SerializeField]
    private float currentHealth;

    public void SetPool(ObjectPool<EnemyBase> pool)
    {
        this.pool = pool;
    }

    private void Die()
    {
        pool.Release(this);
    }

    public void ApplyDamage(float amount)
    {
        var healthText = HealthTextSpawner.Instance.SpawnHealthText(amount.ToString(), Color.red);
        healthText.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

        currentHealth -= amount;
        Debug.Log("HP : " + currentHealth + " / " + Stats.Health);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
