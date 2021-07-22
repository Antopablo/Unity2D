using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue mDialogue;
    public bool mIsInRange;

    private Text mInteractUI;

    private void Awake()
    {
        mInteractUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (mIsInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
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

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(mDialogue);
    }
}
