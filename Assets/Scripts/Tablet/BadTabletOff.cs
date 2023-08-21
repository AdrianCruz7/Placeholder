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
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public void HideTablet()
    {
        lives = manager.GetComponent<Lives>();

        switch (lives.lives)
        {
            case 3:
                heart3.SetActive(false);
                button.SetActive(true);
                screen.SetActive(false);
                sound.Play();
                break;

            case 2:
                heart2.SetActive(false);
                button.SetActive(true);
                screen.SetActive(false);
                sound.Play();
                break;
            
            case 1:
                //game over
                break;
        }
        //reduce health
    }
}
