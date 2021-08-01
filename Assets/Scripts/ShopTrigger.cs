using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public bool mIsInRange;

    private Text mInteractUI;
    public Item[] mItemsToSell;

    public string mPnjName;

    // Update is called once per frame
    private void Awake()
    {
        mInteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mIsInRange = true;
            mInteractUI.enabled = true;
        }
    }

    void Update()
    {
        if (mIsInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(mItemsToSell, mPnjName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mIsInRange = false;
            mInteractUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }

    
}
