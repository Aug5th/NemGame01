using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDistance : MyMonoBehaviour
{
    private CircleCollider2D _circleCollider2D;
    private EnemyBase _enemyBase;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _enemyBase = GetComponentInParent<EnemyBase>();
        _circleCollider2D.radius = 4f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _enemyBase.SetAttackDistanceBool(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemyBase.SetAttackDistanceBool(false);
        }
    }
}
