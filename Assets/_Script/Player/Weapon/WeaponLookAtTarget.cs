using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLookAtTarget : MyMonoBehaviour
{
    [SerializeField]
    private Transform weapon;
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
}
