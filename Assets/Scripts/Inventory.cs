using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public PlayerEffects mPlayerEffects;

    public List<Item> mContent = new List<Item>();
    private int mCurrentIndex = 0;

    public int mCoinsCount;
    public Text mCoinsCountText;

    public Image mItemImageUI;
    public Text mItemNameUI;

    public Sprite mEmptyItemImage;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'Inventory dans la scène.");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if (mContent.Count == 0)
        {
            return;
        }

        Item currentItem = mContent[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        mPlayerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        mContent.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (mContent.Count == 0)
        {
            return;
        }

        mCurrentIndex++;
        if (mCurrentIndex > mContent.Count - 1)
        {
            mCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (mContent.Count == 0)
        {
            return;
        }

        mCurrentIndex--;
        if (mCurrentIndex < 0)
        {
            mCurrentIndex = mContent.Count - 1;
        }
        UpdateInventoryUI();

    }

    public void UpdateInventoryUI()
    {
        if (mContent.Count > 0)
        {
            mItemImageUI.sprite = mContent[mCurrentIndex].image;
            mItemNameUI.text = mContent[mCurrentIndex].itemName;
        }
        else
        {
            mItemImageUI.sprite = mEmptyItemImage;
            mItemNameUI.text = "";

        }
    }

    public void AddCoin(int count)
    {
        mCoinsCount += count;
        UpdateTextUI();

    }

    public void RemoveCoin(int count)
    {
        mCoinsCount -= count;
        UpdateTextUI();

    }

    public void UpdateTextUI()
    {
        mCoinsCountText.text = mCoinsCount.ToString();
    }

}
