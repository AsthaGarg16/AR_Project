using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float currentTime;
    private float maxTime = 1500.0f; // 25 minutes in seconds
    public Button selectAxes;
    public Button selectCoins;

    void Start()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        if (currentTime >= maxTime) {
		selectAxes.gameObject.SetActive(true);
		selectCoins.gameObject.SetActive(true);
		return;
	  }

        currentTime += Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0.0f, maxTime);

        int minutes = Mathf.FloorToInt(currentTime / 60.0f);
        int seconds = Mathf.RoundToInt(currentTime % 60.0f);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "Time: " + timeString;
    }
}
