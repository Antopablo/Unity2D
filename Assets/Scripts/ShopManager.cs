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
        //Supprime les boutons déjà présents
        for (int i = 0; i < mSellButtonsParent.childCount; i++)
        {
            Destroy(mSellButtonsParent.GetChild(i).gameObject);
        }

        // Ajout les boutons
        for (int i = 0; i < items.Length; i++)
        {
            GameObject lButton = Instantiate(mSellButtonPrefab, mSellButtonsParent);
            SellButtonItem lButtonScript = lButton.GetComponent<SellButtonItem>();
            lButtonScript.mItemName.text = items[i].name;
            lButtonScript.mItemImage.sprite = items[i].image;
            lButtonScript.mItemPrice.text = (items[i].price).ToString();

            lButtonScript.mItem = items[i];
            lButton.GetComponent<Button>().onClick.AddListener(delegate { lButtonScript.BuyItem(); });
        }
    }

    public void CloseShop()
    {
        mAnimator.SetBool("isOpen", false);

    }
}
