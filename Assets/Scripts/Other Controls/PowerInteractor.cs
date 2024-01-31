using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************
 * This is a component of the IceSphere GameObject
 * This script allows the IceSphere to have collision and be interacted with
 * Logan Rudsenske 22/1/24
 ****************/

public class PowerInteractor : MonoBehaviour
{
    [SerializeField] private float pushForce;
    private Rigidbody iceSphereRB;
    private IceSphereController iceSphereController;

    // Start is called before the first frame update
    private void Start()
    {
        iceSphereRB = GetComponent<Rigidbody>();
        iceSphereController = GetComponent<IceSphereController>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
