using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamState : EnemyBaseState
{
    private Vector2 _targetPos;
    public override void AnimationCallbackEvent(EnemyStateManager enemyStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        _targetPos = GetRandomPointInCircle(enemyStateManager.Enemy);
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager)
    {
        Roaming(enemyStateManager.Enemy);
        if(enemyStateManager.Enemy.IsWithinAttackDistance)
        {
            enemyStateManager.SwitchState(enemyStateManager.ChaseState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        
    }

    private void Roaming(EnemyBase enemy)
    {
        var direction = (_targetPos - (Vector2)enemy.transform.position).normalized;
        enemy.Move(direction);
        if (((Vector2)enemy.transform.position - _targetPos).sqrMagnitude < 0.01f)
        {
            _targetPos = GetRandomPointInCircle(enemy);
        }
    }

    private Vector2 GetRandomPointInCircle(EnemyBase enemy)
    {
        Vector2 randomPosInCircle = Random.insideUnitCircle * 1f;
        return ((Vector2)enemy.transform.position + randomPosInCircle).normalized;
    }
}
