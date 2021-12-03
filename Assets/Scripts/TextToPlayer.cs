using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextToPlayer : MonoBehaviour
{
    public GameObject text;
    public TextMeshProUGUI playerText;

    public bool banana = false;

    void Start()
    {
        if(playerText == null)
        {
            text = GameObject.FindWithTag("Text");
            playerText = text.GetComponent<TextMeshProUGUI>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Banana"))
        {
            Destroy(other.gameObject);
            banana = true;
            Debug.Log("Potassium");
            playerText.text = "POTASSIUM";
        }
        else if(other.gameObject.CompareTag("Stop1"))
        {
            Destroy(other.gameObject);
            Debug.Log("Stop Everything");
            playerText.text = "STOP EVERYTHING o_O";
        }
        else if(other.gameObject.CompareTag("Stop2"))
        {
            Destroy(other.gameObject);
            Debug.Log("Get the Banana");
            playerText.text = "Get the Banana (*_*)";
        }
        else if(other.gameObject.CompareTag("NoText"))
        {
            playerText.text = "";
        }
    }
}
