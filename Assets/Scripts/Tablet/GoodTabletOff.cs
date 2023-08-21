using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTabletOff : MonoBehaviour
{
    public GameObject button;
    public GameObject screen;
    public AudioSource sound;

    public void HideTablet()
    {
        button.SetActive(true);
        screen.SetActive(false);
        sound.Play();
    }
}
