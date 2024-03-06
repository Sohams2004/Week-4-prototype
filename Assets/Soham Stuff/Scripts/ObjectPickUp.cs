using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] bool isPicked;

    [SerializeField] LayerMask object_;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject, player;

    RaycastHit hit;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void ObjectDetect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, object_))
        {
            Debug.Log("Object detected");
            GameObject hitObj = hit.collider.gameObject;

            if (Input.GetMouseButton(0))
            {
                objectRb = hitObj.GetComponent<Rigidbody>();
                pickableObject = hitObj.gameObject;
                hitObj.transform.position = pickUpPoint.position;
                objectRb.constraints = RigidbodyConstraints.FreezePositionY;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            objectRb.constraints = RigidbodyConstraints.None;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

    private void Update()
    {
        ObjectDetect();
    }
}
