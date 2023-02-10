using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FeedbackSystem : MonoBehaviour
{
    public GameObject levelTube1;
    public Sprite tube1Colored;
    
    public GameObject levelTube2;
    public Sprite tube2Colored;
    
    public GameObject levelTube3;
    public Sprite tube3Colored;
    
    public GameObject levelBunsenBurner;
    public Sprite bunsenBurnerColored;
    
    public GameObject levelLaptop;
    public Sprite laptopColored;


    private Reaction[] reactions = new Reaction[5];
    void Start()
    {
        reactions[0] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), true);
        reactions[1] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), true);
        reactions[2] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), true);
        reactions[3] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), true);
        reactions[4] = new Reaction(new ChemElement("H", Color.red), new ChemElement("O", Color.blue), new ChemElement("H2O", Color.green), true);
    }

    void Update()
    {
        if (reactions[0].finished) {
            ChangeImage(levelTube1, tube1Colored);
        }
        if (reactions[1].finished) {
            ChangeImage(levelTube2, tube2Colored);
        }
        if (reactions[2].finished) {
            ChangeImage(levelTube3, tube3Colored);
        }
        if (reactions[3].finished) {
            ChangeImage(levelBunsenBurner, bunsenBurnerColored);
        }
        if (reactions[4].finished) {
            ChangeImage(levelLaptop, laptopColored);
        }
    }


    private void ChangeImage(GameObject gameObject, Sprite newSprite)
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = newSprite;
    }
}
