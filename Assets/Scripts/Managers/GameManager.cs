using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/****************
 * This is a component of the GameManager GameObject.
 * Its puropse is to manage the player's movement 
 * and stats, the scenes, and the debugging.
 * Logan Rudsenske Version 1.0
 ****************/
public class GameManager : MonoBehaviour
{
    [Header("Player Fields")]
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerRepelForce;
    public float playerBounce;

    [Header("Scene Fields")]
    public GameObject waypoints;

    [Header("Debug Fields")]
    public bool debugSpawnWaves;
    public bool debugSpawnPortal;
    public bool debugSpawnPowerUp;
    public bool debugPowerUpRepel;

    public bool switchLevels {private get; set;}
    public bool gameOver {private get; set;}
    public bool playerHasPowerUp {get; set;}

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void EnablePlayer()
    {

    }

    private void SwitchLevels()
    {

    }
}