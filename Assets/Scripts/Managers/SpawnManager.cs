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
    [SerializeField] private GameObject iceSphere;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject player;

    [Header("Wave Fields")]
    [SerializeField] private int initialWave;
    [SerializeField] private int increaseEachWave;
    [SerializeField] private int maximumWave;

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
        if (GameObject.Find("Player") && FindObjectsOfType<IceSphereController>().Length <= 0)
        {
            SpawnIceWave();
        }
        if (waveNumber > portalFirstAppearance || (GameManager.Instance.debugSpawnPortal = true && !gameObject.CompareTag("Portal")))
        {
            SetObjectActive(portalByWaveProbability, portal);
        }
    }

    private void SpawnIceWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(iceSphere, SetRandomPosition(1.6f), iceSphere.transform.rotation);
        }

        if (waveNumber < maximumWave)
        {
            waveNumber += increaseEachWave;
        }
    }

    private void SetObjectActive(float byWaveProbability, GameObject obj)
    {
        if (Random.value < waveNumber * byWaveProbability * Time.deltaTime)
        {
            obj.transform.position = SetRandomPosition(-0.65f);
            StartCoroutine(CountdownTimer(obj.tag));
        }
    }

    private Vector3 SetRandomPosition(float posY)
    {
        Debug.Log(islandSize);
        float Randomx = Random.Range(-islandSize.x / 2, islandSize.x / 2);
        float Randomz = Random.Range(-islandSize.z / 2, islandSize.z / 2);
        return new Vector3(Randomx, posY, Randomz);
    }

    // Enables the portal, waits, and then disables the portal
    private IEnumerator CountdownTimer(string objectTag)
    {
        float byWaveDuration = 0;
        switch (objectTag)
        {
            case "Portal":
                portal.SetActive(true);
                portalActive = true;
                byWaveDuration = portalByWaveDuration;
                break;
        }

        yield return new WaitForSecondsRealtime(waveNumber * byWaveDuration);
        switch (objectTag)
        {
            case "Portal":
                portal.SetActive(false);
                portalActive = false;
                break;
        }
    }
}
