using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] LayerMask object_;

    [SerializeField] Transform pickUpPoint;

    void ObjectDetect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength, object_))
        {
            Debug.Log("Object detected");
            GameObject hitObj = hit.collider.gameObject;

            if(Input.GetMouseButton(0))
            {
                hitObj.transform.position = pickUpPoint.position;
            }
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
