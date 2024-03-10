using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Keypad : MonoBehaviour 
{
    [SerializeField] string password;

    [SerializeField] public bool isUnlocked;

    [SerializeField] TextMeshProUGUI numText;

    [SerializeField] GameObject keyPad;

    [SerializeField] AudioSource errorSound, correctSound;

    private void Start()
    {
    }

    public void NumberText(string number)
    {
        numText.text += number;

        if (numText.text.Length >= 4)
        {
            numText.text = numText.text.Substring(0, 4);
        }
    }

    IEnumerator CheckPass()
    {
        if (numText.text == password)
        {
            isUnlocked = true;
            correctSound.Play();
            numText.text = "Correct";
            yield return new WaitForSeconds(1);
            keyPad.SetActive(false);
        }

        else if (numText.text == string.Empty)
        {
            numText.text = "No Input";
            yield return new WaitForSeconds(1);
            numText.text = string.Empty;
        }

        else if (numText.text != password && numText.text != string.Empty)
        {
            errorSound.Play();
            numText.text = "Error";
            yield return new WaitForSeconds(1);
            numText.text = string.Empty;
        }
    }

    public void StartCoroutineCheckPass()
    {
        StartCoroutine(CheckPass());
    }

    public void Clear()
    {
        numText.text = null;
    }

    void CloseKeypad()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            keyPad.SetActive(false);
        }
    }

    private void Update()
    {
        CloseKeypad();
    }
}
