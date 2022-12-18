using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Spell : MonoBehaviour
{
    public int _cost;
    public UnityEvent _castEvent;
    public SpellManager _spellManager;

    public virtual void Cast()
    {
        _castEvent.Invoke();
    }
    public virtual void CastEffect()
    {
        Debug.Log(this.name);
    }
   
}
