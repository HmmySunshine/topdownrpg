using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private PlayerController playerController;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    // Start is called before the first frame update
    private void Awake()
    {
        playerController = new PlayerController();
        rb2d = GetComponent<Rigidbody2D>();
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
        Move();
    }

    private void PlayerInput()
    { 
        movement = playerController.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
