using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum AnimationType 
{
    IDLE = 0,
    MOVE = 1, 
    HURT = 2, 
    DIE  = 3,
}

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DoAnimation(AnimationType animType)
    {
        switch (animType)
        {
            case AnimationType.IDLE:
                PlayerIdle();
                break;
            case AnimationType.MOVE:
                PlayerMove();
                break;
            case AnimationType.HURT:
                break;
            case AnimationType.DIE:
                break;
            default:
                break;
        }
    }

    public void FlipSprite(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    private void PlayerMove()
    {
        animator.SetBool("isMoving", true);
    }

    private void PlayerIdle()
    {
        animator.SetBool("isMoving", false);
    }
}
