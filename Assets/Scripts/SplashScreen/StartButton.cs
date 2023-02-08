using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    public GameObject EndButton;

    void Start()
    {
        Button btn = EndButton.GetComponent<Button>();
		btn.onClick.AddListener(moveToGameScene);
    }

    void moveToGameScene() {
        SceneManager.LoadScene("Lab");
    }
}
