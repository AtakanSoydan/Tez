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

    private int totalQuestions = 0;
    public int score;

    [Serializable]
    public class QuestionLists
    {
        public List<QuestionAndAnswers> questions;
    }
    [Header("Questions and Answers")]
    public QuestionLists questionLists = new QuestionLists();

    private void Start()
    {
        GameOverPanel.SetActive(false);
        ReadQuestions();
        GenerateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        QuizPanel.SetActive(false);
        GameOverPanel.SetActive(true);

        ScoreText.text = score + "/" + totalQuestions;

    }

    public void Correct()
    {
        // when your answer is right
        score += 1;
        questionLists.questions.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
    }

    public void Wrong()
    {
        // when your answer is wrong
        questionLists.questions.RemoveAt(currentQuestion);
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
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().StartColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(1).GetComponent<TMP_Text>().text = questionLists.questions[currentQuestion].Answers[i];

            if (questionLists.questions[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (questionLists.questions.Count() > 0 )
        {
            currentQuestion = UnityEngine.Random.Range(0, questionLists.questions.Count);

            QuestionText.text = questionLists.questions[currentQuestion].Question;
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

        totalQuestions = questionLists.questions.Count();
    }
}
