using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int maxScore;
    private int currentScore; 

    public static string scoreString;

    private Reaction[] reactions;

    void Update()
    {
        reactions = DoReaction.reactions;
        currentScore = QuizManager.Solved + getReactionsResults();
        maxScore = QuizManager._totalQuestions + reactions.Length;
        scoreString = currentScore + "/" + maxScore;
    }

    int getReactionsResults() {
        int result = 0;
        for (int i = 0; i < reactions.Length; i++) {
            if (reactions[i].finished) {
                result++;
            }
        }
        return result;
    }
}
