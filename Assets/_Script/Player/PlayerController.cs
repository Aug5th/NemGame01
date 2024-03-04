using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PresistentSingleton<PlayerController>
{
    [SerializeField]
    private WeaponController weaponController;
    public WeaponController WeaponController => weaponController;

    [SerializeField]
    private PlayerMovement _playerMovement;
    public PlayerMovement PlayerMovement => _playerMovement;

    protected override void LoadComponents()
    {
        weaponController = FindObjectOfType<WeaponController>();
        _playerMovement = GetComponentInChildren<PlayerMovement>();
    }


}
