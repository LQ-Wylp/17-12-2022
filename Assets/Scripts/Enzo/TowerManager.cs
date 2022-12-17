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
    private BaseTower _origin;
    
    private bool _taken;
    private bool _hasClicked;
    private PlayerControls _playerControls;
    private InputAction _leftMouseClick;

    private void Start()
    {
            _playerControls = new PlayerControls();
            _playerControls.Game.Enable();
            _leftMouseClick = _playerControls.Game.Click;
            _leftMouseClick.Enable();
    }


    void Update()
    {
        DetectPlacedObject();
        Debug.Log(Mouse.current.position.ReadValue());
        Debug.Log(Mouse.current.leftButton.IsPressed());
    }
    void DetectPlacedObject() //D�tecte si un objet est plac� � l'endroit o� l'utilisateur pointe la souris
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(_mousePosition, transform.forward, Mathf.Infinity, _towerLayer);

        

        // if (_taken)
        // {
        //     transform.position = Mouse.current.position.ReadValue();
        // }

    }

}
