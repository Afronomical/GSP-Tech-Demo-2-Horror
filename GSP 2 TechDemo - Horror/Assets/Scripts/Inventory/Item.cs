using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public enum ItemType
    {
        Gun, bottle, coin, medkit
    }
    public GameObject itemPhysical;
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Gun: return ItemAssets.Instance.Gun;
            case ItemType.bottle: return ItemAssets.Instance.Bottle;
            case ItemType.coin: return ItemAssets.Instance.coin;
            case ItemType.medkit: return ItemAssets.Instance.Medkit;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Gun:
                return false;
                
            case ItemType.bottle:
                return false;
                
            case ItemType.coin:
                return true;
                
            case ItemType.medkit:
                return true;
                
              
        }
    }
}
