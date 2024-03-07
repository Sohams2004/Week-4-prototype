using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRespawn : MonoBehaviour
{
    // Store original positions of the cubes
    private Vector3[] originalPositions;
    
    void Start()
    {
        // Initialize the array to store original positions
        originalPositions = new Vector3[3];

        // Store original positions
        for (int i = 0; i < 3; i++)
        {
            originalPositions[i] = GameObject.FindGameObjectWithTag("Object").transform.position;
        }
    }

    // OnTriggerEnter is called when the cube enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the cube entered the trigger at the edge of the map
        if (other.CompareTag("MapEdge"))
        {
            // Reset the position of the cube to its original position
            transform.position = GetOriginalPosition(gameObject);
        }
    }

    // Function to get the original position of a cube based on its index
    Vector3 GetOriginalPosition(GameObject cube)
    {
        for (int i = 0; i < 3; i++)
        {
            if (cube.transform.position == originalPositions[i])
            {
                return originalPositions[i];
            }
        }
        return Vector3.zero;
    }
}
