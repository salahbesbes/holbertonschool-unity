using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{

    public float maxSpeed = 1000f;
    public float forwardForce = 1000f;
    public Rigidbody rigBod;
    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Adding a force on the Z Axis (to move forward)
        rigBod.AddForce(0, 0, forwardForce * Time.deltaTime);
        
        // Limit velocity
        if (rigBod.velocity.magnitude > maxSpeed)
        {
            rigBod.velocity = Vector3.ClampMagnitude(rigBod.velocity, maxSpeed);
        }
    }
}
