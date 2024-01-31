using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***********************
 * This a component of the IceSphere GameObject and gives it its movement and abilities
 * Logan Rudsenske, 22/1/24
 *********************/

public class IceSphereController : MonoBehaviour
{
    [SerializeField] private float startDelay, reductionEachRepeat, minimumVolume;
    private Rigidbody iceRB;
    private ParticleSystem iceVFX;
    private float pushForce;

    // Start is called before the first frame update
    private void Start()
    {
        if (GameManager.Instance.debugSpawnWaves)
        {
            reductionEachRepeat = 0.5f;
        }
        iceRB = GetComponent<Rigidbody>();
        iceVFX = GetComponent<ParticleSystem>();
        RandomizeSizeAndMass();
        InvokeRepeating("Melt", startDelay, 0.4f);
    }

    // Update is called once per frame
    private void RandomizeSizeAndMass()
    {
        transform.localScale *= 0.5f * Random.value + 0.5f;
        
    }

    private void Dissolution()
    {
        float volume = 4.0f / 3.0f * Mathf.PI * Mathf.Pow(transform.localScale.x, 3);
        int numOfIceSphereInScene = FindObjectsOfType<IceSphereController>().Length;
        if (volume < 0.8f && numOfIceSphereInScene > 1)
        {
            //iceVFX.Stop();
        }

        Debug.Log(volume);
        if (volume < minimumVolume)
        {
            Destroy(gameObject);
        }
    }

    private void Melt()
    {
            transform.localScale *= reductionEachRepeat;
            Dissolution();
        
    }
}
