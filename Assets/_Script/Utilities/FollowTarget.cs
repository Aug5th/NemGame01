using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MyMonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float smoothSpeed = 2f;
    [SerializeField]
    private Vector3 locationOffset = new Vector3(0,0,-1);
    [SerializeField]
    private Vector3 rotationOffset;
    private void FixedUpdate()
    {
        Following();
    }

    private void Following()
    {
        //Vector3 desiredPosition = player.position + player.rotation * locationOffset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        //Quaternion desiredRotation = player.rotation * Quaternion.Euler(rotationOffset);
        //Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        //transform.rotation = smoothedRotation;

        transform.position = Vector3.Lerp(transform.position, player.position, Time.fixedDeltaTime * smoothSpeed);
    }
    protected override void LoadComponents()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        base.LoadComponents();
    }
}
