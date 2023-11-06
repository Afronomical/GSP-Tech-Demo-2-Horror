using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeypadInteractable : InteractableObjectScript
{
    

    public GameObject keypad;

    public GameObject player;

    [SerializeField] Camera keypadCam;
    // Start is called before the first frame update

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && keypad.activeInHierarchy)
        {
            InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Movement);
            //keypad.SetActive(false);
            
        }
    }
    public override void Interact()
    {
        InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Interacting);
        keypad.SetActive(true);
        MoveCamera.Instance.SwitchCamera(keypadCam);
        
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
