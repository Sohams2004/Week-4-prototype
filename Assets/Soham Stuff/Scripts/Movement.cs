using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float Speed;

    [SerializeField] Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * inputz + transform.right * inputx) * Speed * 100 * Time.deltaTime;
        playerRb.velocity = movement;
    }
}
