using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PresistentSingleton<PlayerController>
{
    [SerializeField]
    private Transform player;
    public Transform Player => player;

    [SerializeField]
    private WeaponController weaponController;
    public WeaponController WeaponController => weaponController;

    protected override void LoadComponents()
    {
        player = transform;
        weaponController = FindObjectOfType<WeaponController>();
    }


}
