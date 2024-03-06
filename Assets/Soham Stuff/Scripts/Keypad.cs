using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Keypad : MonoBehaviour
{
    [SerializeField] string password;

    [SerializeField] TextMeshProUGUI numText;

    [SerializeField] GameObject keyPad;

    [SerializeField] AudioSource errorSound, correctSound;

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
            correctSound.Play();
            numText.text = "Correct";
            yield return new WaitForSeconds(1);
            keyPad.SetActive(false);
        }

        else if (numText.text == string.Empty)
        {
            numText.text = "No Input";
            yield return new WaitForSeconds(1);
            numText.text = null;
        }

        else if (numText.text != password)
        {
            errorSound.Play();
            numText.text = "Error";
            yield return new WaitForSeconds(1);
            numText.text = null;
        }
    }

    public void StartCoroutineCheckPass()
    {
        StartCoroutine(CheckPass());
    }

    public void Clear()
    {
        numText.text = "";
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
