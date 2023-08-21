using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image NPCimage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;

    public DialogueStoreScriptableObjects dialogueBank;
    private DialogueStore grabDialogue = new DialogueStore();

    private Queue<string> sentences;

    private void Awake()
    {
        grabDialogue.dialogueNumber = 0;
        grabDialogue.dialogueBank = dialogueBank;
        grabDialogue.PromptUpdate();
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);

        NPCimage.sprite = grabDialogue.pic;

        nameText.text = grabDialogue.names;

        sentences.Clear();

        /*foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }*/

        sentences.Enqueue(grabDialogue.prompt);

        DisplayNextSentence();

        grabDialogue.dialogueNumber++;
        grabDialogue.PromptUpdate();
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
        animator.SetBool("IsOpen", false);
    }

    public void BadEndDialogue()
    {
        //Play shock sound
        //Set tablet down and place on table
        //Reduce Health
    }
    
    public void GoodEndDialogue()
    {
        //Play chime sound
        //Set tablet down and place on table
    }

}
