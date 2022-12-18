using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpell : Spell
{
    public SelectionManager _selectionManager;
    public override void CastEffect()
    { 
        _selectionManager._possibleChanges ++;
    }
}
