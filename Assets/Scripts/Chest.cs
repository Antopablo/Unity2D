using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{


    private Text mInteractUI;
    private bool mIsInRange = false;
    public Animator mAnimator;
    public int mCoinsToAdd;
    public AudioClip mAudioClipOpen;
    public AudioClip mAudioClipCoin;

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
            OpenChest();
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

    private void OpenChest()
    {
        mAnimator.SetTrigger("OpenChest");
        Inventory.instance.AddCoin(mCoinsToAdd);
        AudioManager.instance.PlayClickAt(mAudioClipOpen, transform.position);
        AudioManager.instance.PlayClickAt(mAudioClipCoin, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        mIsInRange = false;
        mInteractUI.enabled = false;
    }
}
