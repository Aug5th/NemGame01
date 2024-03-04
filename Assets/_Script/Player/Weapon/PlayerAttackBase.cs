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

    protected void AttackNearestTarget(ProjectileType projectileType , Transform attackPoint)
    {
        if (nearestTarget == null || !canAttack || !WithinAttackRange())
            return;
           
        var projectile = SpawnProjectile(projectileType, attackPoint , nearestTarget.transform.position);
        StartCoroutine(AllowToAttack(projectile));
        canAttack = false;
    }

    protected void AttackToMousePoint(ProjectileType projectileType, Transform attackPoint)
    {
        if (!canAttack)
            return;
        
        var projectile = SpawnProjectile(projectileType, attackPoint, InputManager.Instance.MousePosition);
        StartCoroutine(AllowToAttack(projectile));
        canAttack = false;
    }

    protected bool WithinAttackRange()
    {
        if (nearestTarget == null)
            return false;
        return Vector2.Distance(PlayerController.Instance.transform.position, nearestTarget.transform.position) < attackDistance;
    }

    protected void GetNearestTarget()
    {
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("Enemy");
        if (allTargets.Length > 0)
        {
            nearestTarget = allTargets[0];
            foreach (GameObject target in allTargets)
            {
                if (Vector2.Distance(PlayerController.Instance.transform.position, target.transform.position) < Vector2.Distance(PlayerController.Instance.transform.position, nearestTarget.transform.position))
                {
                    nearestTarget = target;
                }
            }
        }
    }

    protected ProjectileBase SpawnProjectile(ProjectileType projectileType , Transform attackPoint , Vector3 targetPosition)
    {
        Vector2 direction = targetPosition - attackPoint.position;
        var projectile = ProjectileSpawner.Instance.SpawnProjectile(projectileType);
        projectile.transform.SetPositionAndRotation(attackPoint.position, attackPoint.rotation);

        //if (projectile == null)
        //    return null;
        
        projectile.transform.right = direction;
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectile.Stats.speed;
        projectile.transform.Find("Trail").gameObject.SetActive(true);
        return projectile;
    }

    IEnumerator AllowToAttack(ProjectileBase projectile)
    {
        yield return new WaitForSeconds(projectile.Stats.attackRate);
        canAttack = true;
    }

}
