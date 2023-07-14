using System;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float currentTime = 0f;
    public static bool isTimeRunning;
    private int scorePenalty = 5;
    private float penaltyCounter = 0f;
    private float penaltyThread = 15f;

    private void Start()
    {
        isTimeRunning = true;
    }

    private void Update()
    {
        if (isTimeRunning)
        {
            if (currentTime >= 0)
            {
                currentTime += Time.deltaTime;
                DisplayTime(currentTime);
                //Her 15 saniyede bir score azalsýn...
                penaltyCounter += Time.deltaTime;
                if (penaltyCounter >= penaltyThread)
                {
                    CalculatePenaltyScore();
                    penaltyCounter = 0f;
                }
                Debug.Log("Level Score: " + GameData.levelScore);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CalculatePenaltyScore()
    {
        GameData.levelScore -= scorePenalty;
    }
}
