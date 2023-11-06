using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectScript : MonoBehaviour, IInteractable
{
    public  TextObject viewText;
    // Start is called before the first frame update

    public virtual void Interact()
    {
        
    }
    public void View(bool isViewing)
    {
        GetComponent<Outline>().enabled = isViewing;

        if (isViewing && viewText != null)
        {
            UIManager.instance.SetInteractionUI(viewText.text);
        }
        else
        {
            ResetInteractUI();
        }
    }
    public virtual void Inspect()
    {

    }

    private void ResetInteractUI()
    {
        UIManager.instance.SetInteractionUI("");
    }

    private void OnDestroy()
    {
        ResetInteractUI();
    }
}
