using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBase : MonoBehaviour
{
    [SerializeField] RoundManager _roundManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ennemy")
        {
            _roundManager._baseLife --;
        }
    }
}
