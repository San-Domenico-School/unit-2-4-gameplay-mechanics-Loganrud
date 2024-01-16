using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/****************
 * This is a component of the Player GameObject.
 * Its puropse is to hold the player's speed, 
 * abilities, responses to inputs, and the 
 * player model.
 * Logan Rudsenske Version 1.0
 ****************/
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicator;
    private PlayerInputActions inputActions;
    private Transform focalpoint;
    private float moveForceMagnitude;
    private float moveDirection;
    public bool hasPowerUp { get; private set; }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {

    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {

    }

    private void AssignLevelValues()
    {

    }

    private void Move()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private IEnumerator PowerUpCooldown(float cooldown)
    {
        yield return null; //replace with correct code later
    }
}
