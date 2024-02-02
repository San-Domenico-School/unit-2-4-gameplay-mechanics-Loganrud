using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*************
 * This is a component of the Enemy or obstacle GameObject presumably.
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
        target = GameObject.Find("Player");
        targetRB = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveTowardsTarget();
        Debug.Log(target.gameObject.name);
    }

    private void MoveTowardsTarget()
    {
        navMeshAgent.SetDestination(targetRB.transform.position);
    }
}
