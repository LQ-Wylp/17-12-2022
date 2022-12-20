using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    public List<HealthSystem> _monstersAtRange;
    [SerializeField] Tower _tower;
    float _damageTimer;
    void Start()
    {
        _damageTimer = _tower._cadence;
    }

    // Update is called once per frame
    void Update()
    {
        // _damageTimer -= Time.deltaTime;
        // if (_damageTimer <= 0)
        // {
        //     if (_monstersAtRange.Count < 0)
        //     {
        //        foreach (HealthSystem monster in _monstersAtRange)
        //        {
        //         monster.PrendreDPS(_tower._damage);
        //        }
        //     }

        //     Debug.Log("tick");
        //     _damageTimer = _tower._cadence;
            
        // }
        // Debug.Log(_tower._damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ennemy")
        {
            _monstersAtRange.Add(other.GetComponent<HealthSystem>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ennemy")
        {
            _monstersAtRange.Remove(other.GetComponent<HealthSystem>());
        }
    }
}
