using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.transform);
        }
    }

    void RespawnPlayer(Transform playerTransform)
    {
        
        playerTransform.position = respawnPoint.position;
    }
}
