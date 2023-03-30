using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private const string JUMP_ANIMATION_TRIGGER = "JumpTrigger";
    private const string PLAYER_DAMAGE_TRIGGER = "DamageTrigger";

    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private float horizontalMovement;
    private Animator animator;
    private int jumpLimit = 2;
    private int jumpCount = 0;

    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float lerpMovement = 0.2f;

    private void Start() {
        playerInput = PlayerInput.Instance;
        animator = GetComponent<Animator>();
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
        if (jumpCount < jumpLimit) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger(JUMP_ANIMATION_TRIGGER);
            jumpCount++;
        }
    }

    public void ResetJump() {
        jumpCount = 0;
    }

    public void TakeDamage(int damage) {
        animator.SetTrigger(PLAYER_DAMAGE_TRIGGER);
    }
}

