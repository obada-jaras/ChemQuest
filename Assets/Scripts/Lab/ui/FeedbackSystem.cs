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


    private Reaction[] reactions;

    void Update()
    {
        reactions = DoReaction.reactions;

        if (reactions[0].finished) {
            ChangeImage(levelTube3, tube3Colored);
        }
        if (reactions[1].finished) {
            ChangeImage(levelTube1, tube1Colored);
        }
        if (reactions[2].finished) {
            ChangeImage(levelBunsenBurner, bunsenBurnerColored);
        }
        if (reactions[3].finished) {
            ChangeImage(levelTube2, tube2Colored);
        }
        if (QuizManager.QuizFinished) {
            ChangeImage(levelLaptop, laptopColored);
        }
    }


    private void ChangeImage(GameObject gameObject, Sprite newSprite)
    {
        Image image = gameObject.GetComponent<Image>();
        image.sprite = newSprite;
    }
}
