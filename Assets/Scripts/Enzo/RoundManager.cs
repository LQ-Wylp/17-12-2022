using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RoundManager : MonoBehaviour
{
    [Header ("Timer")]
    [SerializeField] float _roundDuration;
    float _roundTimer;
    [SerializeField] UnityEvent _endTimerEvent;

    
    [Header ("Adversary")]

    public int _baseLife;
    [SerializeField] UnityEvent _endLifeEvent;
    
    void Start()
    {
        _roundTimer = _roundDuration;
    }

    // Update is called once per frame
    void Update()
    {
        _roundDuration -= Time.deltaTime;
        if(_roundDuration <= 0)
        {
            _endTimerEvent.Invoke();
        }

        if(_baseLife <= 0)
        {
            _endLifeEvent.Invoke();
        }
    }

    public void Win()
    {
        Debug.Log("Win");
    }

    public void Lose()
    {
        Debug.Log("Lose");
    }
}
