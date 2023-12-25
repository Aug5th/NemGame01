using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : Singleton<WeaponController>
{
    Vector3 weaponFlipLeft = new Vector3(-0.05f, -0.15f, 0f);
    Vector3 weaponFlipRight = new Vector3(0.05f, -0.15f, 0f);
    private Transform weaponModel;
    public Transform WeaponModel => weaponModel;

    protected override void LoadComponents()
    {
        LoadWeapon();
        base.LoadComponents();
    }

    private void LoadWeapon()
    {
        weaponModel = transform.Find("Model");
    }

    public void FlipWeapon(float direction)
    {
        if (direction > 0)
        {
            transform.localPosition = weaponFlipRight;
        }
        if (direction < 0)
        {
            transform.localPosition = weaponFlipLeft;
        }
    }
}
