using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerQuestion : MonoBehaviour
{
    public bool IsCorrect = false;
    public QuizManager QuizManager;
    public void Answer()
    {
        if (IsCorrect)
        {
            Debug.Log("Correct");
            QuizManager.CorrectAnswer();
        }
        else
        {
            Debug.Log("False");
            QuizManager.Answer();
        }
    }
}
