using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(Winscreen());
        }
    }

    IEnumerator Winscreen()
    {
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        OpenVault();
    }
}
