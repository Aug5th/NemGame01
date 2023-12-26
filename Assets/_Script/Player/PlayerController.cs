using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            collision.GetComponent<ICollectable>().Collect();
        }
    }
}
