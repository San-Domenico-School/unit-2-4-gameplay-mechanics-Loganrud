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
    private Transform focalpoint;
    private float moveForceMagnitude;
    private float moveDirection;
    public bool hasPowerUp { get; private set; }
    private PlayerInputActions inputAction;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
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
        inputAction.Enable();
        inputAction.Player.Movement.performed += OnMovementPreformed;
        inputAction.Player.Movement.canceled += OnMovementCanceled;
        if (GameManager.Instance.debugPowerUpRepel)
        {
            hasPowerUp = true;
        }
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.Player.Movement.performed -= OnMovementPreformed;
        inputAction.Player.Movement.canceled -= OnMovementCanceled;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        if (transform.position.y < -10f)
        {
            GameManager.Instance.gameOver = true;
            Debug.Log("You Lost");
            gameObject.SetActive(false);
        }
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
        transform.localScale = GameManager.Instance.playerScale;
        playerRB.mass = GameManager.Instance.playerMass;
        playerRB.drag = GameManager.Instance.playerDrag;
        moveForceMagnitude = GameManager.Instance.playerMoveForce;
        focalpoint = GameObject.Find("FocalPoint").transform;
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void Move()
    {
        if (focalpoint != null)
        {
            Debug.Log(focalpoint.forward * moveForceMagnitude * moveDirection);
            playerRB.AddForce(focalpoint.forward * moveForceMagnitude * moveDirection);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Startup"))
        {
            
            collision.gameObject.tag = "Ground";
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            AssignLevelValues();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Portal");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            if (transform.position.y <= -1.65)
            {
                transform.position = Vector3.up * 25;
                GameManager.Instance.switchLevels = true;
            }
        }
    }

    private IEnumerator PowerUpCooldown(float cooldown)
    {
        yield return null; //replace with correct code later
    }
}
