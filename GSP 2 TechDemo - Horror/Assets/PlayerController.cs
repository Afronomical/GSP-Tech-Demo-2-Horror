using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Inventory inventory;
    [SerializeField] UIInventory uiInventory;

    private void Start()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        bool inventoryToggle = false;

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryToggle)
            {
                inventoryToggle = !inventoryToggle;
                uiInventory.SetInventory(inventory);
                uiInventory.gameObject.SetActive(inventoryToggle);
                if (inventoryToggle)
                {
                    InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Interacting);
                    
                }
                else
                {
                    InputHandler.instance.ChangeInputState(InputHandler.PlayerInputStates.Movement);
                }
                
            }
            else
            {

            }
        }
    }
    public Inventory getInventory() { return inventory; }
}
