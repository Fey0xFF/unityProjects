using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TypeWriter : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float delay = 0.1f;
    public string fullText;
    public string typeWriterText;
    public string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }


    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            gameObject.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }


}
