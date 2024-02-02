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

    // Determine if the iceshpere collides with the player, and then determine if the player has a powerup
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player") )
        {
            GameObject player = collision.gameObject;
            Rigidbody playerRB = player. GetComponent<Rigidbody>();
            PlayerController playerController = player.GetComponent<PlayerController>();
            Vector3 direction = (player.transform.position - transform.position).normalized;
            if (player.GetComponent<PlayerController>().hasPowerUp)
            {
                iceSphereRB.AddForce(-direction * playerRB.mass * GameManager.Instance.playerRepelForce, ForceMode.Impulse);
            }
            else
            {
                playerRB.AddForce(direction, ForceMode.Force);
            }
        }
    }
}
