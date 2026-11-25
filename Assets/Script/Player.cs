using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private void HandleMovement()
    {
        float moveInputX = 0;
        float moveInputY = 0;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInputX = -1;
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInputX = 1;
        }
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            moveInputY = 1;
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            moveInputY = -1;
        }

        rb.linearVelocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);


    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
}