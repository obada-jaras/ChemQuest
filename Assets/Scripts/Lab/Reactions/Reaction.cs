using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction
{
    public ChemElement chemElement1;
    public ChemElement chemElement2;
    public ChemElement resultChemElement;
    public bool finished;

    public Reaction(ChemElement chemElement1, ChemElement chemElement2, ChemElement resultChemElement, bool finished) {
        this.chemElement1 = chemElement1;
        this.chemElement2 = chemElement2;
        this.resultChemElement = resultChemElement;
        this.finished = finished;
    }
}
