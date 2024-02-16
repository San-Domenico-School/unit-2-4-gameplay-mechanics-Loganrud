using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/****************
 * This is a component of the GameManager GameObject.
 * Its puropse is to manage the player's movement 
 * and stats, the scenes, and the debugging.
 * Logan Rudsenske Version 1.0
 ****************/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Fields")]
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerRepelForce;
    public float playerBounce;

    [Header("Scene Fields")]
    public float NumberOfLevel;
    public GameObject[] waypoints;

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
        //Awake is called before any Start methods are called
        //This is a common approach to handling a class with a reference to itself.
        // If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
        }
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (switchLevels)
        {
            SwitchLevels();
        }
    }

    private void EnablePlayer()
    {

    }

    // Extracts the level number from the string to set then load the next level
    private void SwitchLevels()
    {
        // Stops class from calling this method
        switchLevels = false;

        // Get the name of the currently active scene
        string currentScene = SceneManager.GetActiveScene().name;

        // Extract the level number from the scene name
        int nextLevel = int.Parse(currentScene.Substring(5)) + 1;

        // Check to see if you're at the last level
        if (nextLevel <= SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene("Level " + nextLevel.ToString());
        }

        // If at the last level, ends the game. //*******   More will go here after Prototype  ******* //
        else
        {
            gameOver = true;
            Debug.Log("You won");
        }

    }
}