using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Cam : MonoBehaviour
{
    [SerializeField] float mouseSense, xRotation;

    [SerializeField] Transform player;

    [SerializeField] GameObject cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GetComponent<Transform>();
        cam = GameObject.FindWithTag("MainCamera");
    }

    void CameraControl()
    {
        float X_axis = Input.GetAxis("Mouse X") * mouseSense * 100f * Time.deltaTime;
        float Y_axis = Input.GetAxis("Mouse Y") * mouseSense * 100f * Time.deltaTime;

        xRotation -= Y_axis;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);

        player.Rotate(Vector3.up, X_axis);
        player.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    private void Update()
    {
        CameraControl();
    }
}
