using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [SerializeField] float rayLength;

    [SerializeField] bool isPicked;

    [SerializeField] LayerMask object_, keypad_, door_;

    [SerializeField] Transform pickUpPoint;

    [SerializeField] Rigidbody objectRb;

    [SerializeField] GameObject pickableObject, player, door;

    [SerializeField] GameManager gameManager;
    [SerializeField] Keypad keypad;
    [SerializeField] FPS_Cam fPSCam;

    RaycastHit hit1;
    RaycastHit hit2;
    RaycastHit hit3;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        keypad = FindObjectOfType<Keypad>();
        fPSCam = FindObjectOfType<FPS_Cam>();
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
            fPSCam.enabled = false;
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameManager.keyPadPanel.gameObject.SetActive(false);
            fPSCam.enabled = true;
            keypad.numText.text = string.Empty;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit3, rayLength, door_))
        {
            Debug.Log("Door detected");
            GameObject hitDoor = hit3.collider.gameObject;

            if(Input.GetMouseButton(0))
            {
                door = hitDoor;
                hitDoor.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
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
