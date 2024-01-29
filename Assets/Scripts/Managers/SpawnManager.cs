using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************
 * This is attached to an empty GameObject in the hierarchy called Spawn Manager.
 * This controlls the spawn of enemies as well as the portal at the end of the level.
 * Logan Rudsenske 29 January 2024
 *******************/


public class SpawnManager : MonoBehaviour
{
    [Header("Objects to Spawn")]
    [SerializeField] private GameObject iceSphere, portal, powerUp, player;

    [Header("Wave Fields")]
    [SerializeField] private int initialWave, increaseEachWave, maximumWave;

    [Header("Portal Fields")]
    [SerializeField] private int portalFirstAppearance;
    [SerializeField] private float portalByWaveProbability, portalByWaveDuration;

    [Header("PowerUp Fields")]
    [SerializeField] private int powerUpFirstAppearence;
    [SerializeField] private float powerUpByWaveProbability, powerUpByWaveDuration;

    [Header("Island")]
    [SerializeField] private GameObject island;

    private Vector3 islandSize;
    private int waveNumber;
    private bool portalActive;
    private bool powerUpActive;

    // Start is called before the first frame update
    private void Start()
    {
        islandSize = island.GetComponent<MeshCollider>().bounds.size;
        waveNumber = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameObject.Find("PLayer") && FindObjectsOfType<IceSphereController>().Length < 0)
        {
            SpawnIceWave();
        }
    }

    private void SpawnIceWave()
    {
        
    }

    private void SetObjectActive(float byWaveProbability, GameObject obj)
    {

    }

    private Vector3 SetRandomPosition(float posY)
    {
        return new Vector3();
        float Randomx = Random.Range(-islandSize.x / 2, islandSize.x / 2);
        float Randomz = Random.Range(-islandSize.z / 2, islandSize.z / 2);
    }

    private IEnumerator CountdownTimer(string objectTag)
    {
        yield return null;
    }
}
