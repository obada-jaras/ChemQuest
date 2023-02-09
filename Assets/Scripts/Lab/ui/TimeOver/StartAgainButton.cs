using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartAgainButton : MonoBehaviour
{
    public Button startAgainButton;

    void Start()
    {
        Button btn = startAgainButton.GetComponent<Button>();
        btn.onClick.AddListener(reloadTheScene);
    }

    void reloadTheScene()
    {
        SceneManager.LoadScene("Lab");
    }
}
