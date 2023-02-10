using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class ShortcutsButton : MonoBehaviour
{
    public Button shortcutsButton;

    void Start()
    {
        Button btn = shortcutsButton.GetComponent<Button>();
        btn.onClick.AddListener(showShortcuts);
    }

    void showShortcuts()
    {
        SceneManager.LoadScene("Shortcuts");
    }
}

