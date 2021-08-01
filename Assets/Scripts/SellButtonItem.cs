using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{

    public Text mItemName;
    public Image mItemImage;
    public Text mItemPrice;

    public Item mItem;

    public void BuyItem()
    {
        Inventory lInventory = Inventory.instance;

        if (lInventory.mCoinsCount >= mItem.price)
        {
            lInventory.mContent.Add(mItem);
            lInventory.UpdateInventoryUI();
            lInventory.mCoinsCount -= mItem.price;
            lInventory.UpdateTextUI();
        }
    }
}
