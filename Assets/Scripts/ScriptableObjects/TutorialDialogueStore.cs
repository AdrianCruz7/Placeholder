using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogueStore : MonoBehaviour
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
    public TutorialDialogueStoreScriptableObjects tutorialDialogueBank;

    public void PromptUpdate()
    {
        pic = tutorialDialogueBank.images[dialogueNumber];

        names = tutorialDialogueBank.names[dialogueNumber];

        prompt = tutorialDialogueBank.dialogue[dialogueNumber];
    }
}
