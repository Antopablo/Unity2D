using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Animator mAnimator;
    public Text mPnjNameText;

    public GameObject mSellButtonPrefab;
    public Transform mSellButtonsParent;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }

        instance = this;
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        mPnjNameText.text = pnjName;
        UpdateItemsToSell(items);
        mAnimator.SetBool("isOpen", true);
    }

    void UpdateItemsToSell(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Instantiate(mSellButtonPrefab, mSellButtonsParent);
        }
    }

    public void CloseShop()
    {
        mAnimator.SetBool("isOpen", false);

    }
}
