using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.X))
        {
            CloseWindow();
        }
    }


    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
