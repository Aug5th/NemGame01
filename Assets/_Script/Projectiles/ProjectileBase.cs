using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MyMonoBehaviour
{
    public ProjectileStats Stats { get; private set; }
    public virtual void SetStats(ProjectileStats stats) => Stats = stats;
    public virtual void SendDamage()
    {
        //send Stats.damage
    }
}
