using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttack : PlayerAttackBase
{
    [SerializeField]
    private Transform attackPoint;

    private PlayerController _controller;
    protected override void FixedUpdate()
    {
        WeaponLookAtMouse();
        //WeaponLookAtTarget();
        base.FixedUpdate();   
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        _controller = GetComponentInParent<PlayerController>();
        attackDistance = 5f;
        attackRate = 1f;
    }

    
    protected override void Attack()
    {
        if(InputManager.Instance.MouseLeftClick == 1)
        {
            AttackToMousePoint(ProjectileType.Arrow, attackPoint);
            _controller.PlayerMovement.Move(Vector2.zero);
        } 
    }

    private void WeaponLookAtMouse()
    {
        Vector3 weaponToTarget = InputManager.Instance.MousePosition - transform.parent.position;
        float angle = Mathf.Atan2(weaponToTarget.y, weaponToTarget.x) * Mathf.Rad2Deg;
        Quaternion roration = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, roration, 10f * Time.deltaTime);
    }

    private void WeaponLookAtTarget()
    {
        if (nearestTarget == null || !WithinAttackRange())
            return;

        Vector3 weaponToTarget = nearestTarget.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(weaponToTarget.y, weaponToTarget.x) * Mathf.Rad2Deg;
        Quaternion roration = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, roration, 10f * Time.deltaTime);
    }
}
