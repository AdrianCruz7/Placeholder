using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogueTrigger : MonoBehaviour
{
    public TutorialDialogue dialogue;

    public void TriggerDialogue()
    {
        //FindAnyObjectByType<TutorialDialogueManager>().StartDialogue(dialogue);
    }
}
