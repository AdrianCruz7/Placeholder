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
    public TMP_Text badText;
    public TMP_Text goodText;

    public Animator animator;

    public DialogueStoreScriptableObjects dialogueBank;
    public DialogueStore grabDialogue;

    private Queue<string> sentences;

    private void Awake()
    {
        grabDialogue = new DialogueStore();
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
        badText.text = grabDialogue.incorrectChoice;
        goodText.text = grabDialogue.correctChoice;



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
