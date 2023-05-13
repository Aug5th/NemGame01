using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawner : DistanceDespawner
{
    protected override void DespawnObject()
    {
        PlayerController.Instance.WeaponController.ProjectileSpawner.Despawn(transform.parent);
    }
}
