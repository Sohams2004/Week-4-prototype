using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] Animator door1;

    private void Start()
    {
        door1.enabled = false;
    }

    void OpenDoor()
    {
        door1.enabled = true;
    }

    private void Update()
    {
        OpenDoor();
    }
}
