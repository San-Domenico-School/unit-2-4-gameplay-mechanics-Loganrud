using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*************
 * This is a component of the Enemy GameObject presumably.
 * This tells the enemies where the player, or target is and tells the to move
 * towards it
 * Logan Rudsenske 22/1/24
 ************/

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private GameObject target;
    private Rigidbody targetRB;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void MoveTowardsTarget()
    {

    }
}
