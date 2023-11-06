using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteController : InteractableObjectScript
{
    [Header("Page Setup")]
    bool noteIsOpen = false;
    public GameObject noteCanvas;
    public PageObject page;
    public TMP_Text noteTextAreaUI;
    [Header("Translate text")]
    public GameObject translateCanvas;
    bool translatingText = false;

    private void Start()
    {
        if(page != null)
        {
            SetNoteCanvasText(page.text);
        }
    }
    public override void Interact()
    {
        ShowNote();
    }

    public void SetNoteCanvasText(string newText)
    {
        noteTextAreaUI.text = newText;
    }

    public void ShowNote()
    {
        SetNoteCanvasText(page.text);
        InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Interacting);
        noteCanvas.SetActive(true);
        
    }

    public void DisableNote()
    {
        InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Movement);
        noteCanvas.SetActive(false);
        
        translatingText = false;
        translateCanvas.SetActive(false);
        SetNoteCanvasText("");
    }

    public void TranslateNote()
    {
        translatingText = !translatingText;
        translateCanvas.SetActive(translatingText);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DisableNote();
        }
    }

}
