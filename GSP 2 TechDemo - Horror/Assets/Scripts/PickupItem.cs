using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PickupItem : InteractableObjectScript
{
    Inventory inventory;
    public Item.ItemType currentItemType;
    public int itemAmount = 1;
    public GameObject itemPrefabObject;

    private void Start()
    {
        
    }
    // Start is called before the first frame update

    private void Update()
    {
        if(inventory == null)
        {
            inventory = PlayerController.Instance.getInventory();
        }
    }
    public override void Interact()
    {
        //ScriptableObject IT = ScriptableObject.CreateInstance("Item");
        //inventory.AddItem(new Item { itemType = Item.ItemType.Gun, amount = 1 });
        inventory.AddItem(new Item { itemType = currentItemType, amount = itemAmount, itemPhysical = itemPrefabObject});
        Destroy(gameObject); 
    }



   
}
