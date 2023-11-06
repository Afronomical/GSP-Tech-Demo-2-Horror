using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Inventory inventory;
    [SerializeField] UIInventory uiInventory;
    bool inventoryToggle = false;

    private void Start()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory(); 

        }
    }
    
    public Inventory getInventory() { return inventory; }

    public void ToggleInventory()
    {

        if(uiInventory.gameObject.activeSelf == false)
        {
            Debug.Log("Inventory on");

            InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Interacting);
            uiInventory.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Inventory off");
            InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Movement);
            uiInventory.gameObject.SetActive(false);
        }
    }
}
