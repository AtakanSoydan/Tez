using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTimer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public static float currentTime = 0f;
    public static bool isTimeRunning;
    private float penaltyCounter = 0f;

    [Header("Score Penalty")]
    public int scorePenalty = 10;
    public float penaltyThread = 60f;
    public int[] targetScenes = {2,3};
    int currentScene;
    private void Start()
    {
        isTimeRunning = true;
        currentScene = SceneManager.GetActiveScene().buildIndex;  
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
                Debug.Log("Current Scene" + currentScene);
                for (int i = 0; i < targetScenes.Length; i++)
                {
                    Debug.Log("Target Scene" + targetScenes[i]);
                    if (targetScenes[i] == currentScene)
                    {
                        if (penaltyCounter >= penaltyThread)
                        {
                            CalculatePenaltyScore();
                            penaltyCounter = 0f;
                        }
                    }
                }
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
