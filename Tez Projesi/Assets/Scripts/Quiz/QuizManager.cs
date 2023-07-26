using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour, IDataPersistence
{
    [Header("Data")]
    public TextAsset textAssetData;
    public int currentQuestion;

    [Header("Objects")]
    public GameObject[] options;
    public GameObject QuizPanel;
    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;

    [Header("Reward Section")]
    public Image[] medals;
    public Sprite gold, silver, bronze, grey;

    [Header("Texts")]
    public TMP_Text QuestionText;
    public TMP_Text[] InfoText;

    [HideInInspector]
    private int score;
    public static int gainedScore; 
    string timeText;

    [Serializable]
    public class QuestionLists
    {
        public List<QuestionAndAnswers> questions;
    }

    [Header("Questions and Answers")]
    public QuestionLists questionLists = new QuestionLists();
    private List<QuestionAndAnswers> selectedQuestions = new List<QuestionAndAnswers>();
    private int maxQuestions = 5; // Maximum number of questions to select from the CSV file

    private void Start()
    {
        GameOverPanel.SetActive(false);
        LevelCompletedPanel.SetActive(false);
        ReadQuestions();
        SelectRandomQuestions();
        GenerateQuestion();
    }
    private void GameOver()
    {
        QuizPanel.SetActive(false);
        if(score < 3)
        {
            GameOverPanel.SetActive(true);
        }
        else
        {
            LevelCompletedPanel.SetActive(true);
        }
        // If game completed successfully, check score and change medals color...
        if(LevelCompletedPanel.activeSelf) 
        {
            if(GameData.levelScore < 300) 
            {
                for (int i = 0; i < medals.Length; i++)
                {
                    medals[i].sprite = grey;
                }
            }

            else if (GameData.levelScore >= 300 && GameData.levelScore < 500)
            {
                medals[0].sprite = bronze;
            }

            else if (GameData.levelScore >= 500 && GameData.levelScore < 700)
            {
                medals[0].sprite = bronze;
                medals[1].sprite = silver;
            }

            else if (GameData.levelScore >= 700)
            {
                medals[0].sprite = bronze;
                medals[1].sprite = silver;
                medals[2].sprite = gold;
            }
        }
        // Stop Game Time when game is finished.
        ScoreTimer.isTimeRunning = false;
        for (int i = 0; i < InfoText.Length; i++)
        {
            InfoText[i].text = "Level Score: " + GameData.levelScore.ToString() + "\n"
                + "Time: " + DisplayTime(ScoreTimer.currentTime) + "\n" 
                + "Collected Info: " + GameData.collectedInfo + "\n" 
                + "Correct Answers: " + score + "\n"
                + "Wrong Answers: " + (maxQuestions - score);

        }

        GameData.levelScore -= gainedScore;
    }

    public void Correct()
    {
        // When your answer is right
        score += 1;
        gainedScore += 100;
        GameData.levelScore += 100;
        selectedQuestions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        // When your answer is wrong
        gainedScore -= 50;
        GameData.levelScore -= 50;
        selectedQuestions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        GenerateQuestion();
    }

    void SetAnswers()
    {
        // Setting answers as options length...
        for (int i = 0; i < options.Length; i++)
        {
            // Defining starting sprites all options...
            options[i].GetComponent<Image>().sprite = options[i].GetComponent<AnswerScript>().StartSprite;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(1).GetComponent<TMP_Text>().text = selectedQuestions[currentQuestion].Answers[i];

            if (selectedQuestions[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        // If question count is bigger than 0, generate questions randomly. 
        if (selectedQuestions.Count() > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, selectedQuestions.Count);

            QuestionText.text = selectedQuestions[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }

    void ReadQuestions()
    {
        // Read data from CSV table...
        string[] data = textAssetData.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 6 - 1;
        // Add questions in list 1-1...
        questionLists.questions = new List<QuestionAndAnswers>();
        for (int i = 0; i < tableSize; i++)
        {
            questionLists.questions.Add(new QuestionAndAnswers()
            {
                Question = data[6 * (i + 1)],
                Answers = new string[4]
                {
                    data[6 * (i + 1) + 1],
                    data[6 * (i + 1) + 2],
                    data[6 * (i + 1) + 3],
                    data[6 * (i + 1) + 4]
                },
                CorrectAnswer = int.Parse(data[6 * (i + 1) + 5])
            });
        }

    }

    void SelectRandomQuestions()
    {
        // Select random question and showing on screen...
        if (questionLists.questions.Count <= maxQuestions)
        {
            // If the number of available questions is less than or equal to the maximum number of questions required, use all the available questions
            selectedQuestions = questionLists.questions;
        }
        else
        {
            // Randomly select maxQuestions number of questions from the available questions
            selectedQuestions = questionLists.questions.OrderBy(q => Guid.NewGuid()).Take(maxQuestions).ToList();
        }
    }

    private string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        return timeText;
    }

    public void LoadData(GameData gameData)
    {
        GameData.levelScore = gameData.levelScore2;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.levelScore2 = GameData.levelScore;
    }
}
