using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDialogueManager : MonoBehaviour
{
    public Image NPCimage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;

    //public TutorialDialogueStoreScriptableObjects tutorialDialogueBank;
    private TutorialDialogueStore grabTutorialDialogue = new TutorialDialogueStore();

    private Queue<string> sentences;

    private void Awake()
    {
        grabTutorialDialogue.dialogueNumber = 0;
        //grabTutorialDialogue.tutorialDialogueBank = tutorialDialogueBank;
        grabTutorialDialogue.PromptUpdate();
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(TutorialDialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);

        NPCimage.sprite = grabTutorialDialogue.pic;

        nameText.text = grabTutorialDialogue.names;

        sentences.Clear();

        /*foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }*/

        sentences.Enqueue(grabTutorialDialogue.prompt);

        DisplayNextSentence();

        grabTutorialDialogue.dialogueNumber++;
        grabTutorialDialogue.PromptUpdate();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
    }

}
