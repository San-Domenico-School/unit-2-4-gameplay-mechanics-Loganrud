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
    private PlayerInputActions InputActions;
    private float moveDirection;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Update()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
    
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {

    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {

    }
}
