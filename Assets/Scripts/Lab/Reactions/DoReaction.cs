using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoReaction : MonoBehaviour
{
    GameObject firstElementObject;
    GameObject secondElementObject;

    private Vector3 firstElementOriginalPosition;
    private Vector3 secondElementOriginalPosition;
    private Quaternion firstElementOriginalRotation;
    private Quaternion secondElementOriginalRotation;
    public static Reaction[] reactions;

    bool firstElementSet = false;
    bool secondElementSet = false;

    // Start is called before the first frame update
    void Start()
    {
        reactions = InitializeReactions();
        
    }

    // Update is called once per frame
    void Update()
    {
        setOriginalPositions();

        if(Input.GetKeyDown(KeyCode.Q)) {
            if (firstElementObject != null && secondElementObject != null) {
                Reaction reaction = CheckForReaction(firstElementObject.name, secondElementObject.name, reactions);
                if (reaction != null && reaction.finished == false) {
                    ChemElement result = reaction.resultChemElement;
                    //if the reaction uses bunsen burner
                    if(result.name == "Fire") {
                        Debug.Log("First element: " + firstElementObject.name + " Second element: " + secondElementObject.name);
                        //if the bunsen burner is placed in the first slot
                        if(firstElementObject.name == "Bunsen Burner") {
                            Debug.Log("Fire reaction 1 ");
                            DoFireReaction(secondElementObject, firstElementObject, result.color, true);

                        } else {
                            Debug.Log("Fire reaction 2 ");
                            DoFireReaction(firstElementObject, secondElementObject, result.color, false);
                        }
                    } else {
                        DoRegularReaction(result.color);
                    }
                    reaction.finished = true;
                    Debug.Log("The reaction between " + firstElementObject.name + " and " + secondElementObject.name + " results in " + result.name);
                } else {
                    Debug.Log("Wrong reaction elements, check the correct elements and get them");
                }
            }
        }
    }

    void setOriginalPositions() {
        firstElementObject = SelectTube.tube1;
        secondElementObject = SelectTube.tube2;

        if (firstElementObject != null && firstElementSet == false) {
            firstElementOriginalPosition = firstElementObject.transform.position;
            firstElementOriginalRotation = firstElementObject.transform.rotation;
            firstElementSet = true;
        }
        if (secondElementObject != null && secondElementSet == false) {
            secondElementOriginalPosition = secondElementObject.transform.position;
            secondElementOriginalRotation = secondElementObject.transform.rotation;
            secondElementSet = true;
        }
    }


    Reaction[] InitializeReactions() {
        Reaction[] reactions = {
        new Reaction(
            new ChemElement("Phenolphthalein", Color.clear),
            new ChemElement("Sodium Hydroxid", Color.white),
            new ChemElement("Pink colored solution", Color.magenta),
            false
        ),
        new Reaction(
            new ChemElement("Iodine", new Color(1.0f, 0.8f, 0.0f)),
            new ChemElement("Starch", Color.clear),
            new ChemElement("Blue/Black colored solution", new Color(0.0f, 0.0f, 0.2f)),
            false
        ),
        new Reaction(
            new ChemElement("Copper II sulfate", Color.blue),
            new ChemElement("Bunsen Burner", Color.red),
            new ChemElement("Fire", Color.green),
            false
        ),
        new Reaction(
            new ChemElement("Potassium permanganate", new Color(0.5f, 0.0f, 0.5f)),
            new ChemElement("Sugar and caustic", Color.clear),
            new ChemElement("Color changing solution", Color.magenta),
            false
        )
        };
        return reactions;
    }

    public Reaction CheckForReaction(string firstElement, string secondElement, Reaction[] reactions) {
        foreach (Reaction reaction in reactions) {
            if ((reaction.chemElement1.name == firstElement && reaction.chemElement2.name == secondElement) ||
                (reaction.chemElement1.name == secondElement && reaction.chemElement2.name == firstElement)) {
                return reaction;
            }
        }
        
        return null;
    }

    public void DoRegularReaction(Color color) {
        Vector3 firstElementTargetPos = new Vector3(-1.711f, 0.979f, -0.263f);
        Quaternion firstElementTargetRot = Quaternion.Euler(0, 0, -41.139f);

        Vector3 secondElementTargetPos = new Vector3(-1.22964f, 0.9091046f, -0.263f);
        Quaternion secondElementTargetRot = Quaternion.Euler(0, 0, 41.139f);

        StartCoroutine(MoveToTarget(firstElementObject, firstElementTargetPos, firstElementTargetRot, 2f));
        StartCoroutine(MoveToTarget(secondElementObject, secondElementTargetPos, secondElementTargetRot, 2f));
        StartCoroutine(FillResultFlask(gameObject, color, 2f));

    }

    public void DoFireReaction(GameObject elementObject, GameObject fireObject, Color color, bool first) {
        Vector3 elementTargetPos;
        Quaternion elementTargetRot;

        if(first == true) {
            elementTargetPos = new Vector3(-1.954f, 1.018f, -0.263f);
            elementTargetRot = Quaternion.Euler(0, 0, 35.054f);
        } else {
            elementTargetPos = new Vector3(-1.147f, 1.03f, -0.263f);
            elementTargetRot = Quaternion.Euler(0, 0, -35.054f);
        }
        StartCoroutine(MoveToTarget(elementObject, elementTargetPos, elementTargetRot, 2f));
        StartCoroutine(ChangeFireColorOverTime(fireObject, color, 2f));

    }

    IEnumerator MoveToTarget(GameObject element, Vector3 targetPos, Quaternion targetRot, float duration) {
        Vector3 originalPos = element.transform.position;
        Quaternion originalRot = element.transform.rotation;

        Transform insideSolution = GetSolutionChild(element, "solution").transform;

        if(insideSolution == null) {
            Debug.Log("the solution child cannot be found");
        }
        float t = 0;
        while (t <= 1) {
            //move and rotate the element from original position to target position in the given duration
            t += Time.deltaTime / duration;
            element.transform.position = Vector3.Lerp(originalPos, targetPos, t);
            element.transform.rotation = Quaternion.Lerp(originalRot, targetRot, t);
            //empty the solution inside the chemical element flask
            yield return null;
        }

        t = 0;
        while(t <= 1) {
            t += Time.deltaTime / duration;
            insideSolution.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }
        // yield return new WaitForSeconds(2f);

        t = 0;
        while (t <= 1) {
            //move and rotate the element from target position to original position in the given duration
            t += Time.deltaTime / duration;
            element.transform.position = Vector3.Lerp(targetPos, originalPos, t);
            element.transform.rotation = Quaternion.Lerp(targetRot, originalRot, t);
            yield return null;
        }
    }

    IEnumerator FillResultFlask(GameObject resultFlaskObject, Color color, float duration) {
        GameObject insideSolutionObject = GetSolutionChild(resultFlaskObject, "solution");
        Transform insideSolution = insideSolutionObject.transform;
        Renderer renderer = insideSolutionObject.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material.color = color;
        }
        yield return new WaitForSeconds(2f);

        float t = 0;
        while(t <= 1) {
            t += Time.deltaTime / duration;
            insideSolution.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
    }

    IEnumerator ChangeFireColorOverTime(GameObject element, Color targetColor, float duration) {
        GameObject fireChild = GetSolutionChild(element, "Fire");
        Renderer renderer = fireChild.GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        yield return new WaitForSeconds(2f);
        float t = 0;
        while (t <= 1) {
            t += Time.deltaTime / duration;
            renderer.material.color = Color.Lerp(originalColor, targetColor, t);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        t=0;
        while (t <= 1) {
            t += Time.deltaTime / duration;
            renderer.material.color = Color.Lerp(targetColor,originalColor, t);
            yield return null;
        }

    }

    GameObject GetSolutionChild(GameObject parentGameObject, string name)
    {
        Debug.Log("parent game object: " + parentGameObject.name);
        Transform[] children = parentGameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }
        }
        return null;
    }

    void ChangeColor(GameObject gameObject, Color color) {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material.color = color;
        }
    }
}
