using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public int randMinutes;
    [SerializeField] public Button confirmButton;

    TextMeshProUGUI textClock;
    public TimerAddOn m_timerAddOn;
    private string min;
    DateTime time = DateTime.Now;
    int timeTracker = 0;

    void Start()
    {
        textClock = GetComponent<TextMeshProUGUI>();
        m_timerAddOn = GetComponent<TimerAddOn>();
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');

    }

    // Update is called once per frame
    void Update()
    {
        string hour = LeadingZero(time.Hour);

        // Checking when the button is clicked
        min = LeadingZero(time.Minute + randMinutes);

        Int32.TryParse(min, out int minInt);
        // If the minutes equal or greater than 60 change the hour and minutes
        if (minInt >= 60)
        {
            int hourTemp = minInt / 60;
            hour = LeadingZero(time.Hour + hourTemp);

            int temp = minInt % 60;
            if (temp < 10) { min = "0" + temp.ToString(); }
            else { min = temp.ToString(); }

        }
        Int32.TryParse(hour, out int hourInt);
        hourInt = hourInt % 12;
        if(hourInt == 0) { hourInt = 12; }
        hour = hourInt.ToString();


        //timeTracker += randMinutes;
        //if (randMinutes >= 30)
        //{
        //    //Debug.Log("TimeTracker: " + timeTracker);
        //    Application.Quit();
        //    Debug.Log("Quit");
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        textClock.text = hour + ":" + min;

        //confirmButton.onClick.AddListener(delegate { ParameterOnClick("Pressed!"); });
    }

    private void ParameterOnClick(string test)
    {


        //Debug.Log(min);
    }
}
