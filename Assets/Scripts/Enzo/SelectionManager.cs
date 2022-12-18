using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SelectionManager : MonoBehaviour
{
    private Vector2 _mousePosition;
    private PlayerControls _playerControls;
    private InputAction _leftMouseClick;
    public List<Tower> _Copains;
    // Start is called before the first frame update
    void Start()
    {
        _playerControls = new PlayerControls();
        _playerControls.Game.Enable();
        _leftMouseClick = _playerControls.Game.Click;
        _leftMouseClick.Enable();
        Tower[] unNom = GameObject.FindObjectsOfType<Tower>();
        for (int i = 0; i < unNom.Length; i++)
        {
            _Copains.Add(unNom[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PrendreUnePersonne(Tower CopainPris)
    {
        for (int i = 0; i < _Copains.Count; i++)
        {
            if (_Copains[i] != CopainPris)
            {
                _Copains[i]._qqunPrisPasMoi = true;
            }
        }
    }
    public void AuSuivant()
    {
        for (int i = 0; i < _Copains.Count; i++)
        {


            _Copains[i]._qqunPrisPasMoi = false;

        }
    }

}
