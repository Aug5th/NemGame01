using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void AnimationCallbackEvent(EnemyStateManager enemyStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager)
    {
        ChasePlayer(enemyStateManager.Enemy);
        if (!enemyStateManager.Enemy.IsWithinAttackDistance)
        {
            enemyStateManager.SwitchState(enemyStateManager.RoamState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
       
    }

    private void ChasePlayer(EnemyBase enemy)
    {
        var target = PlayerController.Instance.Player;
        Vector3 direction = target.position - enemy.transform.position;
        enemy.Move(direction);
    }
}
