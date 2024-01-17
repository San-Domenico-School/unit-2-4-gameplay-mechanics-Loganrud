using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/****************
 * This is a component of the FocalPoint GameObject.
 * Its puropse is to hold the player's rotation, 
 * movement direction, and responses to inputs.
 * Logan Rudsenske Version 1.0
 ****************/
public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private PlayerInputActions inputAction;
    private float moveDirection;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Rotate the focalpoints which the camera is attached to
    private void Update()
    {
        transform.Rotate(Vector3.up, moveDirection * rotationSpeed * Time.deltaTime);
    }

    // Add OnMovement events to inputAction's Player's movement
    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.Player.Movement.performed += OnMovementPreformed;
        inputAction.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.Player.Movement.performed -= OnMovementPreformed;
        inputAction.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>().x;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = 0.0f;
    }
}
