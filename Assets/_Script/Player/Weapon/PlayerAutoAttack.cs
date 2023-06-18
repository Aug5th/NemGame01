using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : PlayerAttackBase
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        attackDistance = 6f;
        attackRate = 0.05f;
    }
    protected override void Attack()
    {
        //AttackNearestTarget(ProjectileSpawner.Fireball);
    }
}
