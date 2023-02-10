using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class ExitShortcuts : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(showSplashScreen);
    }

    void showSplashScreen()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}

