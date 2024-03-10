using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] bool isPicked;

    [SerializeField] LayerMask object_, keypad_;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject, player;

    [SerializeField] GameManager gameManager;
    [SerializeField] Keypad keypad;

    RaycastHit hit1;
    RaycastHit hit2;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        keypad = FindObjectOfType<Keypad>();
    }

    void ObjectDetect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit1, rayLength, object_))
        {
            Debug.Log("Object detected");
            GameObject hitObj = hit1.collider.gameObject;

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

        if (Physics.Raycast(transform.position, transform.forward, out hit2, rayLength, keypad_) && keypad.isUnlocked != true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.keyPadPanel.gameObject.SetActive(true);
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameManager.keyPadPanel.gameObject.SetActive(false);
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
