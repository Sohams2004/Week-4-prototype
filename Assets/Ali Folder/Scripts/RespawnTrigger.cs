using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform respawnPointCube1;
    public Transform respawnPointCube2;
    public Transform respawnPointCube3;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.transform);
        }

        if (other.CompareTag("Object1"))
        {
            RespawnCube1(other.transform);
        }

        if (other.CompareTag("Object2"))
        {
            RespawnCube2(other.transform);
        }

        if (other.CompareTag("Object3"))
        {
            RespawnCube2(other.transform);
        }


    }

    void RespawnPlayer(Transform playerTransform)
    {
        
        playerTransform.position = respawnPoint.position;
    }

    void RespawnCube1(Transform CubeTransform)
    {
        
        CubeTransform.position = respawnPointCube1.position;
    }

    void RespawnCube2(Transform CubeTransform)
    {
        
        CubeTransform.position = respawnPointCube2.position;
    }

    void RespawnCube3(Transform CubeTransform)
    {
        
        CubeTransform.position = respawnPointCube3.position;
    }
}
