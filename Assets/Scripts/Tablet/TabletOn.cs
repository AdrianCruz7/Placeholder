using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletOn : MonoBehaviour
{
    [SerializeField]
    public GameObject button;
    public GameObject screen;
    public GameObject dialogueManager;
    private DialogueManager dialogue;
    private Dialogue d;

    public void HideButton()
    {
        button.SetActive(false);
        screen.SetActive(true);
        dialogue = dialogueManager.GetComponent<DialogueManager>();
        dialogue.StartDialogue(d);
    }
}
