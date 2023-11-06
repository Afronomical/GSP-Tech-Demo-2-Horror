using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateTextScript : MonoBehaviour
{
    [SerializeField]TMP_Text noteText;
    
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<TMP_Text>().text  != noteText.text)
        {
            this.gameObject.GetComponent<TMP_Text>().text = noteText.text;

        }
    }
}
