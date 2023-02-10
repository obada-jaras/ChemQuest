using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_DoneReactions : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;

    private Reaction[] reactions;

    void Update()
    {
        reactions = DoReaction.reactions;

        if (reactions[0].finished) {
            t1.SetActive(true);
        }
        if (reactions[1].finished) {
            t2.SetActive(true);
        }
        if (reactions[2].finished) {
            t3.SetActive(true);
        }
        if (reactions[3].finished) {
            t4.SetActive(true);
        }
    }
}
