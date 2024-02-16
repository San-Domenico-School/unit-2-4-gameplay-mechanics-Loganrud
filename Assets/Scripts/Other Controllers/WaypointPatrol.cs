using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    private GameObject[] waypoints;
    private NavMeshAgent navMeshAgent;
    private int waypointIndex;

    // Start is called before the first frame update
    private void Start()
    {
        waypoints = GameManager.Instance.waypoints;
        navMeshAgent = gameObject.GetComponent <NavMeshAgent>();
        waypointIndex = Random.Range(0, waypoints.Length);

    }

    // Update is called once per frame
    private void Update()
    {
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        navMeshAgent.SetDestination(waypoints[waypointIndex].transform.position);
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 3f && waypointIndex < 15)
        {
            waypointIndex = ++waypointIndex;
        }
    }
}
