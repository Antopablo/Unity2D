using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator mAnimator;

    public Text mNameText;
    public Text mDialogueText;

    private Queue<string> mSentences;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }

        instance = this;

        mSentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue pDialogue)
    {

        mAnimator.SetBool("isOpen", true);

        mNameText.text = pDialogue.mName;

        mSentences.Clear();

        foreach (string sent in pDialogue.mSentences)
        {
            // met la phrase en file d'attente
            mSentences.Enqueue(sent);
        }

        DiplayNextSentence();
    }

    public void DiplayNextSentence()
    {
        //toutes les phrases sont passées
        if (mSentences.Count == 0)
        {
            EndDialogues();
            return;
        }

        // récu_père le prochain élement de la file d'attente
        string lSentence = mSentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(lSentence));
    }

    IEnumerator TypeSentence(string pSentence)
    {
        mDialogueText.text = "";

        foreach (char letter in pSentence.ToCharArray())
        {
            mDialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogues()
    {
        mAnimator.SetBool("isOpen", false);

    }
}
