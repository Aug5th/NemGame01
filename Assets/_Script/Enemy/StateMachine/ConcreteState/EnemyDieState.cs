using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public override void AnimationCallbackEvent(EnemyStateManager enemyStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.Enemy.Move(Vector2.zero);
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        
    }
}
