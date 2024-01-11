using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable
{
    bool IsKnockingBack { get; set; }
    float KnockbackTime { get; set; }

    void StartKnockback(Transform impactPos, float force);

    IEnumerator KnockbackRoutine();
}
