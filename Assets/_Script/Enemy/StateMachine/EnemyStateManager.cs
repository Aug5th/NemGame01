using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MyMonoBehaviour
{
    public EnemyBase Enemy;
    public EnemyBaseState CurrentState;

    public EnemyRoamState RoamState = new();
    public EnemyChaseState ChaseState = new();
    public EnemyAttackState AttackState = new();
    public EnemyDazeState DazeState = new();
    public EnemyDieState DieState = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        Enemy = GetComponent<EnemyBase>();
    }

    private void Start()
    {
        CurrentState = RoamState;
        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        CurrentState.FixedUpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        CurrentState = newState;
        CurrentState.EnterState(this);
    }
}
