using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TowerManager : MonoBehaviour
{
    [SerializeField] float _cadence;
    [SerializeField] float _range;
    [SerializeField] LayerMask _towerLayer;

    private Vector2 _mousePosition;
    [SerializeField] BaseTower _origin;
    private BaseTower _hoveredBase;
    
    private bool _taken;
    private bool _canBeTaken;
    private PlayerControls _playerControls;
    private InputAction _leftMouseClick;
    private FollowMouse _cursor;
    bool _canBePlaced;

    private void Start()
    {
            _playerControls = new PlayerControls();
            _playerControls.Game.Enable();
            _leftMouseClick = _playerControls.Game.Click;
            _leftMouseClick.Enable();
            _cursor = GameObject.FindObjectOfType<FollowMouse>();
            transform.position = _origin.transform.position;

    }


    void Update()
    {
        //TakeObject();
       
        Debug.Log(Mouse.current.leftButton.IsPressed());
        if(_canBeTaken && Mouse.current.leftButton.IsPressed())
        {
            TakeObject();
        }
        
        if(_taken && !Mouse.current.leftButton.IsPressed())
        {
            if(_canBePlaced)
            {
                transform.position = _hoveredBase.transform.position;
                _origin = _hoveredBase;
            }
            else{
                transform.position = _origin.transform.position;
            }
        }

    }
    void TakeObject() //D�tecte si un objet est plac� � l'endroit o� l'utilisateur pointe la souris
    {
        
        _taken = true;
        transform.position = _cursor.transform.position;
        

        

        // if (_taken)
        // {
        //     transform.position = Mouse.current.position.ReadValue();
        // }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "cursor")
        {
            _canBeTaken = true;
        }
        if(other.GetComponent<BaseTower>() != null)
        {
            _hoveredBase = other.GetComponent<BaseTower>();
            _canBePlaced = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.name == "cursor")
        {
            _canBeTaken = false;
        }
         if(other.GetComponent<BaseTower>() != null)
        {
            _hoveredBase = null;
            _canBePlaced = false;
        }

    }

}
