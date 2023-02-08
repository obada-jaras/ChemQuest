using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject firstPersonCharacter;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

        updatePositionAndRotation();
    }

    
    void grabObject(RaycastHit obj)
    {
    }

    void releaseObject()
    {
    }


    void updatePositionAndRotation()
    {
    }
}
