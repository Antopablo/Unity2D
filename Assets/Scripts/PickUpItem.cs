using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text mInteractUI;
    private bool mIsInRange = false;

    public AudioClip mAudioClip;

    public Item mItem;

    // Start is called before the first frame update
    void Awake()
    {
        mInteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && mIsInRange)
        {
            TakeItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mIsInRange = true;
            mInteractUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mIsInRange = false;
            mInteractUI.enabled = false;
        }
    }

    private void TakeItem()
    {
        Inventory.instance.mContent.Add(mItem);
        Inventory.instance.UpdateInventoryUI();

        AudioManager.instance.PlayClickAt(mAudioClip, transform.position);
        mInteractUI.enabled = false;

        Destroy(gameObject);
    }
}
