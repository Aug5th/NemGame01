using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : MyMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

    protected abstract bool CanDespawn();

    protected virtual void Despawning()
    {
        if (!CanDespawn())
            return;
        Debug.Log("Call DespawnObject");
        DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
