using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject TimeOverPopup;
    public GameObject scoreText;

    public static float timeRemaining;
    private Text timerText;

    void Start()
    {
        if (timeRemaining <= 0)
        {
            timeRemaining = 179f;
        }

        timerText = GetComponent<Text>();
        TimeOverPopup.SetActive(false);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.RoundToInt(timeRemaining % 60f);
            timerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        }
        else
        {
            scoreText.GetComponent<Text>().text = ScoreSystem.scoreString;
            TimeOverPopup.SetActive(true);
            Cursor.visible = true;
        }
    }
}
 