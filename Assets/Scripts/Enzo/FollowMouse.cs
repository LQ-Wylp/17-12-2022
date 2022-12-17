using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class FollowMouse : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 niquetarace = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        niquetarace.z = 0;
        transform.position = niquetarace;
    }
}
