using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PickupKey : InteractableObjectScript
{
    Inventory inventory;

    private void Start()
    {
        inventory = PlayerController.Instance.getInventory();
    }
    // Start is called before the first frame update

    public override void Interact()
    {

        inventory.AddItem(new Item { itemType = Item.ItemType.Gun, amount = 1 });
        Destroy(gameObject); 
    }

   
}
