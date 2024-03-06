using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public Animator doorAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            // Trigger the door animation to play
            doorAnimator.SetTrigger("Open");
        }
    }
}
