using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public Color StartColor;

    private void Start()
    {
        StartColor = GetComponent<Image>().color;          
    }

    public void Answer()
    {
        GetComponent<Image>().color = StartColor;

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correnct Answer");
            quizManager.Correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}
