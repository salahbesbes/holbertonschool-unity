using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 500f;
    public float SideForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddForce(0, 0, Speed * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(SideForce * Time.deltaTime, 0,0);
        }
        if (Input.GetKey("q"))
        {
            rb.AddForce(-SideForce * Time.deltaTime, 0, 0);

        }
    }
}
