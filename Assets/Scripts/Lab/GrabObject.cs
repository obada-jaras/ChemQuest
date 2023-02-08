using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GrabObject : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.collider.gameObject.name + "\t|\tSINGLE HIT");
                if (hit.collider.gameObject.tag == "grab")
                {
                    grabObject(hit);
                }

                else
                {
                    RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
                    foreach (RaycastHit h in hits)
                    {
                        // Debug.Log(h.collider.gameObject.name + "\t|\tMULTIPLE HITS");
                        if (h.collider.gameObject.tag == "grab")
                        {
                           grabObject(h); 
                        }
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
    }

    void openLaptop()
    {
        SceneManager.LoadScene("Laptop");
        // Cursor.visible = false;
    }
}
