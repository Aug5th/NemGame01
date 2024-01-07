using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class EnemyBase : MyMonoBehaviour, IDamageable
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private EnemyAnimationHandler _animationHandler;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private EnemyStateManager _enemyStateManager;


    private ObjectPool<EnemyBase> _pool;
    private bool _beAttacked;

    public EnemyStats Stats { get; private set; }
    public bool IsWithinAttackDistance { get; set; }

    [SerializeField] protected List<ItemStructure> dropList = new List<ItemStructure>();
    [SerializeField] protected GameObject hitVFX;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        _healthBar = GetComponentInChildren<HealthBar>();
        _animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyStateManager = GetComponent<EnemyStateManager>();

        SetDropItems();
    }

    public virtual void SetStats(EnemyStats stats)
    {
        Stats = stats;
        _currentHealth = _maxHealth = Stats.Health;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        _healthBar.gameObject.SetActive(false);
    }

    protected virtual void SetDropItems()
    {
        ItemStructure item = new ItemStructure();
        item.ItemCode = ItemCode.Gold;
        item.Quantity = 1;
        dropList.Add(item);
    }

    public void SetPool(ObjectPool<EnemyBase> pool)
    {
        _pool = pool;
    }

    private void Die()
    {
        _enemyStateManager.SwitchState(_enemyStateManager.DieState);
        _animationHandler.OnTriggerAnimation(EnemyAnimationHandler.AnimationEvent.DIE);
    }

    public void ReleaseEnemy()
    {
        // release enemy
        _pool.Release(this);
        // drop items
        DropItems();

    }
    public void DropItems()
    {
        var dropChanceList = ItemSpawner.Instance.ItemDropRateList;
        foreach (var item in dropList)
        {
            var dropChance = dropChanceList[item.ItemCode];
            var random = Random.Range(1, 100);
            if (random <= dropChance)
            {
                Vector3 offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                var spawnItem = ItemSpawner.Instance.SpawnItem(item.ItemCode);
                spawnItem.SetInventoryItem(item);
                spawnItem.transform.SetLocalPositionAndRotation(transform.position + offset, Quaternion.identity);
            }
        }

    }
    public void ApplyDamage(float amount)
    {
        var healthText = HealthTextSpawner.Instance.SpawnHealthText(amount.ToString(), Color.red);
        healthText.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

        _currentHealth -= amount;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        Instantiate(hitVFX, transform.position, Quaternion.identity);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Move(Vector2 direction)
    {
        rigidbody2D.velocity = direction * Stats.MovementSpeed * Time.deltaTime;
    }

    public void SetAttackDistanceBool(bool isWithinAttackDistance)
    {
        IsWithinAttackDistance = isWithinAttackDistance;
    }

}
