using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public bool _isEmpty;
    public Tower _tower;

    private void Update()
    {
        if (_tower == null)
            _isEmpty = true;
        else
            _isEmpty = false;
    }
}
