using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Camera mainCamera;
    public Camera MainCamera => mainCamera;

    protected override void LoadComponents()
    {
        mainCamera = FindObjectOfType<Camera>();
        base.LoadComponents();
    }

}


