using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MyMonoBehaviour
{
    [SerializeField]
    private Vector3 mousePosition;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private PlayerController _player;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        rb = GetComponentInParent<Rigidbody2D>();
        
    }

    private void Start()
    {
        _player = PlayerController.Instance;
    }

    private void Update()
    {
        FlipObjects();
        PlayerMove();
    }

    private void FlipObjects()
{
        Vector3 direction =  InputManager.Instance.MousePosition - _player.transform.position;
        FlipPlayer(direction.x);
        _player.WeaponController.FlipWeapon(direction.x);
    }

    private void PlayerMove()
    {
        float inputX = InputManager.Instance.HorizontalInput;
        float inputY = InputManager.Instance.VerticalInput;
        if (inputX != 0 || inputY != 0)
        {
            PlayerAnimation.Instance.DoAnimation(AnimationType.MOVE);
        }
        else
        {
            PlayerAnimation.Instance.DoAnimation(AnimationType.IDLE);
        }
        Vector3 direction = new Vector3(inputX, inputY, 0).normalized;
        var velocity = direction * speed;
        Move(velocity);
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void FlipPlayer(float x)
    {
        if (x < 0)
            PlayerAnimation.Instance.FlipSprite(true);
        if (x > 0)
            PlayerAnimation.Instance.FlipSprite(false);
    }

    private void FollowCursor()
    {
        mousePosition = InputManager.Instance.MousePosition;
        mousePosition.z = 0;

        Vector3 newPosition = Vector3.Lerp(transform.parent.position, mousePosition, speed);
        transform.parent.position = newPosition;
    }
}
