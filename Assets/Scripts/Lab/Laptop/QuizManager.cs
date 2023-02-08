using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions;
    public GameObject[] buttons;
    public int CurrentQuestion;
    public TMPro.TMP_Text Question;

    public GameObject QuizPanel;
    public GameObject EndPanel;

    private int _totalQuestions = 0;
    public int Solved = 0;
    public TMPro.TMP_Text Score;
    
    private void Start()
    {
        _totalQuestions = questions.Count;
        ShowQuizPanel();
        GenerateQuestion();
    }

    public void CorrectAnswer()
    {
        UpdateScore();
        Answer();
    }

    private void UpdateScore()
    {
        Solved++;
        Score.text = "Score: " + Solved.ToString() + "/" + _totalQuestions.ToString();
    }

    public void Answer()
    {

        questions.RemoveAt(CurrentQuestion);

        if (questions.Count > 0)
        {
            GenerateQuestion();
        }
        else
        {
            ShowEndScreen();
        }

    }

    private void ShowQuizPanel()
    {
        QuizPanel.SetActive(true);
        EndPanel.SetActive(false);
    }

    private void ShowEndScreen()
    {
        QuizPanel.SetActive(false);
        EndPanel.SetActive(true);
    }

    private void GenerateQuestion()
    {
        CurrentQuestion = Random.Range(0, questions.Count);
        Question.text = questions[CurrentQuestion].QuestionText;

        PutAnswersInButtons();
    }
    private void PutAnswersInButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.GetComponentInChildren<TMPro.TMP_Text>().text = questions[CurrentQuestion].Answers[i];

            if (questions[CurrentQuestion].CorrectAnswer == i)
            {
                buttons[i].GetComponent<AnswerQuestion>().IsCorrect = true;
            }
            else
            {
                buttons[i].GetComponent<AnswerQuestion>().IsCorrect = false;
            }

        }
    }
}
