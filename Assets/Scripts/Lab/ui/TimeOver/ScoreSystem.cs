using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int maxScore;
    private int currentScore; 
    void Start()
    {
        maxScore = QuizManager._totalQuestions + 1;
        currentScore = QuizManager.Solved + 1;
    }

    void Update()
    {
        currentScore = QuizManager.Solved + 1;
        // Debug.Log("Score: " + currentScore.ToString() + "/" + maxScore.ToString());
    }
}
