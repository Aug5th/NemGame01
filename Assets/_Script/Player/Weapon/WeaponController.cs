using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MyMonoBehaviour
{
    Vector3 weaponFlipLeft = new Vector3(-0.1f, -0.4f, 0f);
    Vector3 weaponFlipRight = new Vector3(0.1f, -0.4f, 0f);
    private Transform weapon;

    protected override void LoadComponents()
    {
        LoadWeapon();
        base.LoadComponents();
    }

    private void LoadWeapon()
    {
        weapon = transform;
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
