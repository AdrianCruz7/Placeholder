using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	//[SerializeField] Slider healthMeter;
	////[SerializeField] Slider timeMeter;
	////[SerializeField] Slider timeStopMeter;
	////[SerializeField] Slider timeCooldownMeter;
	//[SerializeField] TMP_Text scoreUI;
	//[SerializeField] TMP_Text coinUI;
	////[SerializeField] TMP_Text timerUI;
	[SerializeField] GameObject GameEndUI;
	[SerializeField] GameObject titleUI;
	[SerializeField] GameObject EndOfDayUI;
	[SerializeField] GameObject ShowDeadScreenUI;
	//[SerializeField] GameObject victoryUI;

	public void ShowTitle(bool show = true)
	{
		//Debug.Log("Title");
		titleUI.SetActive(show);
	}

	public void ShowGameEnd(bool show = true)
	{
        GameEndUI.SetActive(show);

	}

	public void ShowDeadScreen(bool show = true)
	{
        ShowDeadScreenUI.SetActive(show);
    }

    public void ShowGameWin(bool show = true)
    {
        //Debug.Log("Win yippee");
        //victoryUI.SetActive(show);
    }

	public void ShowEndOfDay(bool show)
	{
		EndOfDayUI.SetActive(show);
	}

	public void SetHealth(int health)
	{
		//healthMeter.value = Mathf.Clamp(health, 0, 100);
	}

	//public void SetTimer(TimeSpan time)
	//{
	//timerUI.text = time.Minutes + ":" + time.Seconds + ":" + time.Milliseconds;
	//}

	public void SetScore(int score)
	{
		//scoreUI.text = score.ToString();
	}

    public void SetCoin(int coin)
    {
       // coinUI.text = coin.ToString();
    }

    //public void SetTimeStop(float time, float max)
    //{
    //	timeStopMeter.value = Mathf.Clamp(time, 0, max);
    //	timeStopMeter.maxValue = max;
    //}
    //public void SetTimeCooldown(float cooldown, float max)
    //{
    //	timeCooldownMeter.value = Mathf.Clamp(cooldown, 0, max);
    //	timeCooldownMeter.maxValue = max;
    //}
}
