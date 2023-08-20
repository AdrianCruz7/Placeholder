using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textClock;
    private float randMinutes = UnityEngine.Random.Range(5, 10);

    void Start()
    {
        textClock = GetComponent<TextMeshProUGUI>();
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');

    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour - 5);
        string min = LeadingZero(time.Minute);
       // string sec = LeadingZero(time.Second);

        //Testing if time can be subtracted of the real time clock
        // Current time 2:50 AKA 14:50
        //Expected time 7:50 19:50
        hour = LeadingZero(time.Hour + 5);
        

        textClock.text = hour + ":"+ min;
    }
}
