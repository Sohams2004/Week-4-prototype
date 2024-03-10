using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeypadActivate : Keypad
{
    [SerializeField] Animator vaultDoor;

    private void Start()
    {
        vaultDoor.enabled = false;
    }

    public void OpenVault()
    {
        if(isUnlocked == true)
        {
            vaultDoor.enabled = true;
        }
    }

    private void Update()
    {
        OpenVault();
    }
}
