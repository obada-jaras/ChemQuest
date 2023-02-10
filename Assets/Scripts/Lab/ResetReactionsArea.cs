using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetReactionsArea : MonoBehaviour
{
    public GameObject selectedTubeLabel;

    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;

    private GameObject[] objectsToReset;

    private void Start()
    {
        // Get all the objects you want to reset
        // get all the objects with tag 'grab'
        objectsToReset = GameObject.FindGameObjectsWithTag("grab");

        // Store the initial position, rotation, and scale of each object
        initialPositions = new Vector3[objectsToReset.Length];
        initialRotations = new Quaternion[objectsToReset.Length];
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].transform.position;
            initialRotations[i] = objectsToReset[i].transform.rotation;
        }
    }

    private void Update()
    {
        // If the user presses the R key, reset the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        // Reset the position, rotation, and scale of each object
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].transform.position = initialPositions[i];
            objectsToReset[i].transform.rotation = initialRotations[i];
        }

        selectedTubeLabel.GetComponent<UnityEngine.UI.Text>().text = "Selected Tube: None";
    }
}
