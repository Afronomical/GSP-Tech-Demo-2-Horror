using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{

    public TMP_Text AnswerText = null;
    [SerializeField] string password = "1234";
    [SerializeField] bool answerCorrect = false;
    [SerializeField] bool canType = true;
    [SerializeField] int passwordLength = 4;

    public Material correctColour;
    public Material incorrectColour;
    public Material defaultColour;

    private Material[] colours = new Material[3];

    [SerializeField] int colourChangeDelay;

    [SerializeField] Image indicator;

    [SerializeField]KeypadMode keypadMode;

    public GameObject gate;

    public enum KeypadMode {reading, incorrect, correct}

   

        
    private void Start()
    {
        colours[0] = defaultColour;
        colours[1] = incorrectColour;
        colours[2] = correctColour;

        keypadMode = KeypadMode.reading;
    }

    public void addNumber(int num)
    {
        if (SpaceToType() && !answerCorrect && canType)
        {
            AnswerText.text += num.ToString();
            if (GameManager.Instance.getDebugMode())
            {
                Debug.Log("Typed: " + num);

            }

            
        }
        
    }
    public void removeNum()
    {
        if (AnswerText.text.Length > 0 && !answerCorrect && canType)
        {
            AnswerText.text = AnswerText.text.Remove(AnswerText.text.Length - 1);
        }
    }
    public void clearAll()
    {
        if (canType)
        {
            if (AnswerText.text.Length > 0 && !answerCorrect)
            {
                AnswerText.text = "";
            }
        }
        
    }
    public void checkAnswer()
    {   
        
       if(!answerCorrect)
        {
            if (AnswerText.text.Length == passwordLength)
            {
                if (AnswerText.text == password)
                {
                    answerCorrect = true;
                    StopAllCoroutines();
                    StartCoroutine(IndicatorColourChange(KeypadMode.correct));
                    UnlockKeypad();
                    //correct logic
                }
                else
                {
                    
                    StopAllCoroutines();
                    StartCoroutine(IndicatorColourChange(KeypadMode.incorrect, true));
                    
                }
                if (GameManager.Instance.getDebugMode())
                {
                    Debug.Log("Answer correct is " + answerCorrect);

                }
            }
            else
            {
                
            }
        }
        

        
    }
   public bool SpaceToType()
    {
        if(AnswerText.text.Length >= passwordLength)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetIndicatorColour()
    {
        indicator.material = colours[(int)keypadMode];
        
    }

    IEnumerator IndicatorColourChange(KeypadMode mode, bool reset = false)
    {
        if (reset)
        {
            canType = false;
        }
        keypadMode = mode;
        SetIndicatorColour();
        //play audio
        yield return new WaitForSeconds(colourChangeDelay);

        if (reset)
        {

            keypadMode = KeypadMode.reading;
            SetIndicatorColour();
            canType = true;
            clearAll();
        }
        
    }

    private void UnlockKeypad()
    {
        gate.SetActive(false);
    }
    
}
