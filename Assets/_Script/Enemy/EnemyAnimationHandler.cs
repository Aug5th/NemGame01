using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : MyMonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyBase _enemy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        _enemy = GetComponentInParent<EnemyBase>();
        _animator = GetComponent<Animator>();
    }

    public void ReleaseEnemy()
    {
        _enemy.ReleaseEnemy();
    }

    public void OnTriggerAnimation(AnimationEvent ev)
    {
        switch (ev)
        {
            case AnimationEvent.IDLE:
                _animator.Play("idle");
                break;
            case AnimationEvent.WALK:
                _animator.Play("walk");
                break;
            case AnimationEvent.DIE:
                _animator.Play("die");
                break;
            default:
                break;
        }
    }

    public enum AnimationEvent{
        IDLE = 0,
        WALK = 1,
        DIE = 2,
    }
}
