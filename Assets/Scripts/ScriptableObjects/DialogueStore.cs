using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStore : MonoBehaviour
{
    [SerializeField]
    public int dialogueNumber = 0;
    [SerializeField]
    public Sprite pic;
    [SerializeField]
    public string names;
    [SerializeField]
    public string prompt;
    [SerializeField]
    public int minutes;
    [SerializeField]
    public string correctChoice;
    [SerializeField]
    public string incorrectChoice;
    [SerializeField]
    public DialogueStoreScriptableObjects dialogueBank;

    public void PromptUpdate()
    {
        pic = dialogueBank.images[dialogueNumber];

        names = dialogueBank.names[dialogueNumber];
        //Debug.Log(name);

        prompt = dialogueBank.dialogue[dialogueNumber];
        //Debug.Log(prompt);

        minutes = dialogueBank.minutes[dialogueNumber];
        //Debug.Log(minutes);

        correctChoice = dialogueBank.evilOption[dialogueNumber];
        //Debug.Log(correctChoice);

        incorrectChoice = dialogueBank.goodOption[dialogueNumber];
        //Debug.Log(incorrectChoice);
    }
}
