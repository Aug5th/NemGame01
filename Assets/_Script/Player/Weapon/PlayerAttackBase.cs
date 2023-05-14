using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttackBase : MyMonoBehaviour
{
    [SerializeField]
    protected float attackDistance = 7f;
    [SerializeField]
    protected float attackRate = 0.1f;
    [SerializeField]
    protected float projectileSpeed = 10f;

    [SerializeField]
    protected GameObject nearestTarget;
    [SerializeField]
    private bool canAttack = true;

    protected virtual void Update()
    {
        GetNearestTarget();
    }

    protected virtual void FixedUpdate()
    {
        Attack();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected abstract void Attack();

    protected void AttackNearestTarget(int projectileType , Transform attackPoint)
    {
        if (nearestTarget == null || !canAttack || !WithinAttackRange())
            return;
           
        SpawnProjectile(projectileType, attackPoint , nearestTarget.transform.position);
        StartCoroutine(AllowToAttack());
        canAttack = false;
    }

    protected void AttackToMousePoint(int projectileType, Transform attackPoint)
    {
        if (!canAttack)
            return;
        
        SpawnProjectile(projectileType, attackPoint, InputManager.Instance.MousePosition);
        StartCoroutine(AllowToAttack());
        canAttack = false;
    }

    protected bool WithinAttackRange()
    {
        if (nearestTarget == null)
            return false;
        return Vector2.Distance(PlayerController.Instance.Player.position, nearestTarget.transform.position) < attackDistance;
    }

    protected void GetNearestTarget()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");
        if (allTargets.Length > 0)
        {
            nearestTarget = allTargets[0];
            foreach (GameObject target in allTargets)
            {
                if (Vector2.Distance(PlayerController.Instance.Player.position, target.transform.position) < Vector2.Distance(PlayerController.Instance.Player.position, nearestTarget.transform.position))
                {
                    nearestTarget = target;
                }
            }
        }
    }

    protected void SpawnProjectile(int projectileType , Transform attackPoint , Vector3 targetPosition)
    {
        Vector2 direction = targetPosition - attackPoint.position;
        Transform projectile = PlayerController.Instance.WeaponController.ProjectileSpawner.Spawn(projectileType, attackPoint.position, attackPoint.rotation);
        if (projectile == null)
            return;
        projectile.gameObject.SetActive(true);
        projectile.right = direction;
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;
    }

    IEnumerator AllowToAttack()
    {
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }

}
