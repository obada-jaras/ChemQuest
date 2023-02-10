using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectTube : MonoBehaviour
{
    public static GameObject selectedTube;

    public static GameObject tube1;
    public static GameObject tube2;
    public GameObject selectedTubeLabel;
    public Button grabTubeButton;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            handleMouseClick();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedTube != null)
            {
                if (tube1 == null)
                {
                    tube1 = selectedTube;
                    moveTube(new Vector3(-2.021f, 0.7923398f, -0.263f));
                }
                else if (tube2 == null)
                {
                    tube2 = selectedTube;
                    moveTube(new Vector3(-1f, 0.7923398f, -0.263f));
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (tube1 == null || tube2 == null)
            {
                grabTubeButton.GetComponentInChildren<Text>().text = "Press E to Grab Tube";
                if (selectedTube != null)
                {
                    grabTubeButton.gameObject.SetActive(true);
                }
            }
            else
            {
                grabTubeButton.GetComponentInChildren<Text>().text = "Press Q to Start the Reaction";
                grabTubeButton.gameObject.SetActive(true);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            grabTubeButton.gameObject.SetActive(false);
        }
    }

    void moveTube(Vector3 targetPosition)
    {
        if (selectedTube != null)
        {
            selectedTube.transform.position = targetPosition;
            selectedTube = null;
            updateSelectedTubeLabel("None");
        }
    }





    void handleMouseClick()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "grab")
            {
                grabObject(hit);
            }

            else
            {
                RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
                foreach (RaycastHit h in hits)
                {
                    if (h.collider.gameObject.tag == "grab")
                    {
                        grabObject(h);
                    }
                }
            }
        }
    }

    
    void grabObject(RaycastHit obj)
    {
        string objectName = obj.collider.gameObject.name;
        if (objectName == "laptop1" || objectName == "laptop" || objectName == "screen")
        {
            openLaptop();
        }
        else 
        {
            updateSelectedTube(obj);
        }
    }

    void openLaptop()
    {
        SceneManager.LoadScene("Laptop");
    }

    void updateSelectedTube(RaycastHit obj)
    {
        selectedTube = obj.collider.gameObject;
        updateSelectedTubeLabel(selectedTube.name);
    }

    void updateSelectedTubeLabel(string name)
    {
        selectedTubeLabel.GetComponent<UnityEngine.UI.Text>().text = "Selected Tube: " + name;
    }
}
