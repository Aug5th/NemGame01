using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class EnemyBase : MyMonoBehaviour , IDamageable
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private EnemyAnimationHandler _animationHandler;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    private ObjectPool<EnemyBase> _pool;
    public EnemyStats Stats { get; private set; }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        _healthBar = GetComponentInChildren<HealthBar>();
        _animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
    }

    public virtual void SetStats(EnemyStats stats)
    {
        Stats = stats;
        _currentHealth = _maxHealth = Stats.Health;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
    }

    

    public void SetPool(ObjectPool<EnemyBase> pool)
    {
        this._pool = pool;
    }

    private void Die()
    {
        _animationHandler.OnTriggerAnimation(EnemyAnimationHandler.AnimationEvent.DIE);
    }

    public void ReleaseEnemy()
    {
        // drop items

        // release enemy
        _pool.Release(this);

    }

    public void ApplyDamage(float amount)
    {
        var healthText = HealthTextSpawner.Instance.SpawnHealthText(amount.ToString(), Color.red);
        healthText.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

        _currentHealth -= amount;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
