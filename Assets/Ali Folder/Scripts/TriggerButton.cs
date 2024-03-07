using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public Animator doorAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object1"))
        {
            
            doorAnimator.SetTrigger("Open");
        }

        if (other.CompareTag("Object2"))
        {
            
            doorAnimator.SetTrigger("Open");
        }

        if (other.CompareTag("Object3"))
        {
            
            doorAnimator.SetTrigger("Open");
        }
    }
}
