using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    //public Color StartColor;
    public Sprite StartSprite;
    public Sprite Red;
    public Sprite Green;

    private void Start()
    {
        //StartColor = GetComponent<Image>().color;
        StartSprite = GetComponent<Image>().sprite;
    }

    public void Answer()
    {
        GetComponent<Image>().sprite = StartSprite;

        if (isCorrect)
        {
            GetComponent<Image>().sprite = Green;
            Debug.Log("Correnct Answer");
            quizManager.Correct();
        }
        else
        {
            GetComponent<Image>().sprite = Red;
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }
}
