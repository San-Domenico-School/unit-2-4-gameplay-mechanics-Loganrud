using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private float cooldown, rotationSpeed;

    // Start is called before the first frame update
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    // returns cooldown
    public float GetCooldown()
    {
        return cooldown;
    }
}
