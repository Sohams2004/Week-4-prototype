using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject keyPadPanel;
    [SerializeField] Movement movement;

    private void Start()
    {
        movement = FindObjectOfType<Movement>();
        keyPadPanel.SetActive(false);
    }
}
