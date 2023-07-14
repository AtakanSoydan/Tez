using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [Header("Data")]
    public TextAsset textAssetData;
    public int currentQuestion;

    [Header("Objects")]
    public GameObject[] options;
    public GameObject QuizPanel;
    public GameObject GameOverPanel;

    public TMP_Text QuestionText;
    public TMP_Text ScoreText;

    public int score;

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
        ReadQuestions();
        SelectRandomQuestions();
        GenerateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        QuizPanel.SetActive(false);
        if(score < 3)
        {
            GameOverPanel.SetActive(true);
        }
        ScoreTimer.isTimeRunning = false;
        ScoreText.text = score + "/" + maxQuestions;
    }

    public void Correct()
    {
        // when your answer is right
        score += 1;
        GameData.levelScore += 100;
        selectedQuestions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        // when your answer is wrong
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
        for (int i = 0; i < options.Length; i++)
        {
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
        string[] data = textAssetData.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 6 - 1;

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
}
