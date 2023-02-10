using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int maxScore;
    private int currentScore; 

    public static string scoreString;

    private Reaction[] reactions = new Reaction[2];
    void Start()
    {
        reactions[0] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), false);
        reactions[1] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), true);
    }

    void Update()
    {
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
