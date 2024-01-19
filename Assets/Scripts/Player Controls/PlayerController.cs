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
    private PlayerInputActions inputAction;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Moves the player to the next level after current level ends
        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerUpIndicator = GetComponent<Light>();
        playerCollider.material.bounciness = 0.4f;
        powerUpIndicator.intensity = 0.0f;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void OnMovementPreformed(InputAction.CallbackContext value)
    {
         moveDirection = value.ReadValue<Vector2>().y;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = 0.0f;
    }

    private void AssignLevelValues()
    {
        GameManager.Instance.playerScale = transform.localScale;
        GameManager.Instance.playerMass = playerRB.mass;
        GameManager.Instance.playerDrag = playerRB.drag;
        GameManager.Instance.playerMoveForce = moveForceMagnitude;
        focalpoint = GameObject.Find("Focal Point").transform;
    }

    private void Move()
    {
        if (focalpoint != null)
        {
            playerRB.AddForce(focalpoint.forward * moveForceMagnitude * moveDirection);
        }
    }

    private void OnColliderEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Ground"))
        {
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            AssignLevelValues();
        }
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
