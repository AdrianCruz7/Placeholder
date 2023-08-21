using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStore : MonoBehaviour
{
    [SerializeField]
    public int dialogueNumber = 0;
    [SerializeField]
    private string prompt;
    [SerializeField]
    private int minutes;
    [SerializeField]
    private string correctChoice;
    [SerializeField]
    private string incorrectChoice;
    [SerializeField]
    private DialogueStoreScriptableObjects dialogueBank;

    private int delay = 0;
    private int maxDelay = 1000;

    private void Start()
    {
        prompt = dialogueBank.dialogue[dialogueNumber];
        Debug.Log(prompt);

        minutes = dialogueBank.minutes[dialogueNumber];
        Debug.Log(minutes);

        correctChoice = dialogueBank.evilOption[dialogueNumber];
        Debug.Log(correctChoice);

        incorrectChoice = dialogueBank.goodOption[dialogueNumber];
        Debug.Log(incorrectChoice);
    }

    private void Update()
    {
        delay++;
        if (delay == maxDelay)
        {
            prompt = dialogueBank.dialogue[dialogueNumber];
            Debug.Log(prompt);

            minutes = dialogueBank.minutes[dialogueNumber];
            Debug.Log(minutes);

            correctChoice = dialogueBank.evilOption[dialogueNumber];
            Debug.Log(correctChoice);

            incorrectChoice = dialogueBank.goodOption[dialogueNumber];
            Debug.Log(incorrectChoice);

            delay = 0;
        }
    }
}
