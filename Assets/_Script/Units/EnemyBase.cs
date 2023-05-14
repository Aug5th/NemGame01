using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MyMonoBehaviour
{
    public EnemyStats Stats { get; private set; }
    public virtual void SetStats(EnemyStats stats) => Stats = stats;
    public virtual void ReceiveDamage(int damage)
    {
        
    }
}
