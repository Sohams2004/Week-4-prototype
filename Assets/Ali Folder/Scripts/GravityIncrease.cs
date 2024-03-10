using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIncrease : MonoBehaviour
{
   public float extraGravityMultiplier = 2f; // Adjust this value to increase falling speed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply extra gravity to increase falling speed
        rb.AddForce(Vector3.down * extraGravityMultiplier, ForceMode.Acceleration);
    }
}
