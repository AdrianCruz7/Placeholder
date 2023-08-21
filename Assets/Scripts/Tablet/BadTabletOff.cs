using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTabletOff : MonoBehaviour
{
    [SerializeField]
    public GameManager manager;
    public GameObject button;
    public GameObject screen;
    public AudioSource sound;
    public Lives lives;

    public void HideTablet()
    {
        lives = manager.GetComponent<Lives>();

        if(lives.lives != 1)
        {
            button.SetActive(true);
            screen.SetActive(false);
            sound.Play();
        }
        
        

        //reduce health
    }
}
