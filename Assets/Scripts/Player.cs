using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private float horizontalMovement;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float lerpMovement = 0.2f;

    private void Start() {
        playerInput = PlayerInput.Instance;
        rb = GetComponent<Rigidbody2D>();
        playerInput.OnJumpEvent += OnJumpEventPerformed;
    }

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement() {
        horizontalMovement = playerInput.GetPlayerMovementNormalized().x;

        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(horizontalMovement * moveSpeed, rb.velocity.y), lerpMovement);
    }

    private void OnJumpEventPerformed(object sender, EventArgs e) {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

