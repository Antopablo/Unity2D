using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool mIsInRange;
    private PlayerMovements mPlayerMovement;
    public BoxCollider2D mCollider;
    private Text mInteractUI;

    void Awake()
    {
        mPlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
        mInteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mIsInRange && mPlayerMovement.mIsClimbing && Input.GetKeyDown(KeyCode.E))
        {
            mPlayerMovement.mIsClimbing = false;
            mCollider.isTrigger = false;
            return;
        }


        if (mIsInRange && Input.GetKeyDown(KeyCode.E))
        {
            mPlayerMovement.mIsClimbing = true;
            mCollider.isTrigger = true;
            mInteractUI.enabled = false;
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
        mIsInRange = false;
        mPlayerMovement.mIsClimbing = false;
        mCollider.isTrigger = false;
        mInteractUI.enabled = false;
    }
}
