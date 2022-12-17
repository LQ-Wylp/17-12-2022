using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    bool _isEmpty;
    public void EmptySwitch()
    {
        _isEmpty = !_isEmpty;
    }
}
