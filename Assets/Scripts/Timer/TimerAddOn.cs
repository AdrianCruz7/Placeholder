using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAddOn : MonoBehaviour
{
    public Timer m_timer;
    public Button YesBttn;
    int randMinutesMin;
    int randMinutesMax;
    int timeTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = YesBttn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Timer time = m_timer.GetComponent<Timer>();
    }

    void TaskOnClick()
    {
        randMinutesMin = 5;
        randMinutesMax = 10;
       
        m_timer.randMinutes += Random.Range(randMinutesMin, randMinutesMax);
        Debug.Log(m_timer.randMinutes);
    }


}
