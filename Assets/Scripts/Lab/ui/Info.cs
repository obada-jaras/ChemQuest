using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public GameObject window;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            window.SetActive(!window.activeSelf);
        }
    }
}
