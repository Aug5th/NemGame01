using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemyStateManager);
    public abstract void UpdateState(EnemyStateManager enemyStateManager);
    public abstract void FixedUpdateState(EnemyStateManager enemyStateManager);
    public abstract void OnCollisionEnter(EnemyStateManager enemyStateManager);
    public abstract void AnimationCallbackEvent(EnemyStateManager enemyStateManager);

}
