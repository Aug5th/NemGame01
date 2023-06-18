using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    private Vector3 mousePosition;
    public Vector3 MousePosition => mousePosition;

    [SerializeField]
    private float verticalInput;
    public float VerticalInput => verticalInput;

    [SerializeField]
    private float horizontalInput;
    public float HorizontalInput => horizontalInput;

    [SerializeField]
    private float mouseLeftClick;
    public float MouseLeftClick => mouseLeftClick;
    [SerializeField]
    private float mouseRightClick;
    public float MouseRightClick => mouseRightClick;


    void Update()
    {
        GetInputs();
        GetMousePosition();
    }

    private void GetInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseLeftClick = Input.GetAxis("Fire1");
        mouseRightClick = Input.GetAxis("Fire2");
    }

    public void GetMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
