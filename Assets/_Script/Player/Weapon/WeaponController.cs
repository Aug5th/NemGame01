using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MyMonoBehaviour
{
    Vector3 weaponFlipLeft = new Vector3(-0.2f, -0.7f, 0f);
    Vector3 weaponFlipRight = new Vector3(0.2f, -0.7f, 0f);
    private Transform weapon;

    [SerializeField]
    private ProjectileSpawner projectileSpawner;

    public ProjectileSpawner ProjectileSpawner => projectileSpawner;

    protected override void LoadComponents()
    {
        LoadWeapon();
        base.LoadComponents();
    }

    private void LoadWeapon()
    {
        weapon = transform;
        projectileSpawner = FindObjectOfType<ProjectileSpawner>();
    }

    public void FlipWeapon(float direction)
    {
        if (direction > 0)
        {
            weapon.localPosition = weaponFlipRight;
        }
        if (direction < 0)
        {
            weapon.localPosition = weaponFlipLeft;
        }
    }
}
