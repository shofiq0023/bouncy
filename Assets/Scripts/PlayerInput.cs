using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    public static PlayerInput Instance;
    private PlayerInputActions playerInputActions;
    public delegate void OnJump();
    public event OnJump OnJumpEvent;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("There is more than one instance!");
        } else {
            Instance = this;
        }

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += OnJumpEventPerformed;
    }

    public Vector2 GetPlayerMovementNormalized() {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    private void OnJumpEventPerformed(InputAction.CallbackContext context) {
        OnJumpEvent?.Invoke();
    }
}
