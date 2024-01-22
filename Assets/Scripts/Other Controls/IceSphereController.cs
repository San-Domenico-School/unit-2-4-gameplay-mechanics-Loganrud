using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***********************
 * This a component of the IceSphere GameObject and gives it its movement and abilities
 * Logan Rudsenske, 22/1/24
 *********************/

public class IceSphereController : MonoBehaviour
{
    [SerializeField] private float startDelay; private float reductionEachRepeat; private float minimumVolume;
    private Rigidbody iceRB;
    private ParticleSystem iceVFX;
    private float pushForce;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void RandomizeSizeAndMass()
    {
        
    }

    private void Dissolution()
    {

    }

    private void Melt()
    {

    }
}
