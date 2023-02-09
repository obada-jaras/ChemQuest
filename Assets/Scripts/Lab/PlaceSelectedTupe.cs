using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaceSelectedTupe : MonoBehaviour
{
    public Button grabTubeButton;
    public GameObject selectedTube;

    void update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            moveTube();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            grabTubeButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            grabTubeButton.gameObject.SetActive(false);
        }
    }

    void moveTube()
    {
        
        if (selectedTube != null)
        {
            selectedTube.transform.position = new Vector3(-1.949f, 0f, -0.815f);
        }
    }
}   
