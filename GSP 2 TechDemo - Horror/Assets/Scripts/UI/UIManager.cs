using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header ("Audio UI")]
    [SerializeField] TextMeshProUGUI subtitleText;

    [Header("Interaction UI")]
    [SerializeField] TextMeshProUGUI InteractionText;

    [Header("Stamina UI")]
    [SerializeField] float stamina;
    [SerializeField] Image staminaBar;
    



    private void Awake()
    {
        UIManager.instance = this;
        ClearSubtitle();

    }
    public void SetSubtitle(string text, float delay)
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text));

        StartCoroutine(ClearAfterSecond(delay));
    }

    public void ClearSubtitle()
    {
        subtitleText.text = "";
    }
    private IEnumerator ClearAfterSecond(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
    private IEnumerator TypeSentence(string sentence)
    {
        subtitleText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            subtitleText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void SetInteractionUI(string text)
    {
        InteractionText.text = text;
    }

    public void SetStaminaUI(float currentStaminaPercent)
    {
       stamina = currentStaminaPercent;
       staminaBar.fillAmount = stamina + 0.15f;
    }
    
}
