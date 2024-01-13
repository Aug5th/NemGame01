using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    Cinemachine.CinemachineStateDrivenCamera cinemachine;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        cinemachine = GetComponentInChildren<Cinemachine.CinemachineStateDrivenCamera>();
        cinemachine.Follow = PlayerController.Instance.Player;
    }
}
