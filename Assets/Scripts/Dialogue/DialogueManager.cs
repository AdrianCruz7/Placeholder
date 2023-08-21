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

    private Queue<string> sentences;
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
<<<<<<< Updated upstream
=======
<<<<<<< HEAD

        NPCimage.sprite = dialogue.image;
        
=======
>>>>>>> 8a48cf293e628a8f4f43cee0e29ab489fa805959
>>>>>>> Stashed changes

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
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
<<<<<<< Updated upstream
        //animator.SetBool("IsOpen", false);
=======
<<<<<<< HEAD
       // animator.SetBool("IsOpen", false);
=======
        //animator.SetBool("IsOpen", false);
>>>>>>> 8a48cf293e628a8f4f43cee0e29ab489fa805959
>>>>>>> Stashed changes
    }

}
