using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDespawner : Despawner
{
    [SerializeField]
    protected float maxDistance = 70f;
    [SerializeField]
    private float distance;
    [SerializeField]
    private Transform mainCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    private void LoadCamera()
    {
        if (mainCamera != null)
            return;
        mainCamera = Transform.FindObjectOfType<Camera>().transform;
    }

    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(transform.position, mainCamera.position);
        if (distance > maxDistance)
            return true;
        return false;
    }   
}
