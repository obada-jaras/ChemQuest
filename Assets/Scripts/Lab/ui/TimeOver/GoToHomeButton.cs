using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GoToHomeButton : MonoBehaviour
{
    public Button goToHomeButton;

    void Start()
    {
        Button btn = goToHomeButton.GetComponent<Button>();
        btn.onClick.AddListener(moveToSplashScreen);
    }

    void moveToSplashScreen()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
