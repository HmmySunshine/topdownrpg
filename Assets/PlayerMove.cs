using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int MoveX = Animator.StringToHash("moveX");
    
    [SerializeField] private float moveSpeed = 1f;
    private PlayerController playerController;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 testPosition;
    
    // Start is called before the first frame update
    private void Awake()
    {
        playerController = new PlayerController();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
        
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    { 
        movement = playerController.Movement.Move.ReadValue<Vector2>();

        
        
        animator.SetFloat(MoveX, movement.x);
        animator.SetFloat(MoveY, movement.y);
    }

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + movement * (moveSpeed * Time.fixedDeltaTime));
        
        
    }

    private void AdjustPlayerFacingDirection()
    {
        //正方向
        testPosition = playerController.Movement.MouseDirection.ReadValue<Vector2>();
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        
        if (testPosition.x < playerScreenPoint.x )
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        
        
    }
    
    
    
}
