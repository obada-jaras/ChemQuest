using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(moveToGameScene);
    }

    void moveToGameScene() {
        SceneManager.LoadScene("Lab");
    }
}
