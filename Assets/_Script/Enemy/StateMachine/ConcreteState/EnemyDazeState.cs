using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDazeState : EnemyBaseState
{
    public override void AnimationCallbackEvent(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.Enemy.Move(Vector2.zero);
    }

    public override void FixedUpdateState(EnemyStateManager enemyStateManager)
    {
        if(!enemyStateManager.Enemy.IsKnockingBack)
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
}
