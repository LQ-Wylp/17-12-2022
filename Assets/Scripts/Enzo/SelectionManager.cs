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
    public int _possibleChanges; 
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

    public void EchangerDeuxTours(Tower t1, Tower t2)
    {
        BaseTower BT1 = t1._origin;
        BaseTower BT2 = t2._origin;

        Transform Socle1Transform = BT1.transform;
        Transform Socle2Transform = BT2.transform;

        t1.transform.position = Socle2Transform.position;
        t2.transform.position = Socle1Transform.position;

        t1._origin = BT2;
        t2._origin = BT1;

        BT1._tower = t2;
        BT2._tower = t1;

        t1._hoveredBase = null;
        t2._hoveredBase = null;

        _possibleChanges --;

    }

    public void MePlacerSurUnSocleVide(Tower t1)
    {
        BaseTower BT1 = t1._origin;
        BaseTower BT2 = t1._hoveredBase;

        Transform Socle1Transform = BT1.transform;
        Transform Socle2Transform = BT2.transform;

        t1.transform.position = Socle2Transform.position;

        t1._origin = BT2;

        BT1._tower = null;
        BT2._tower = t1;

        t1._hoveredBase = null;
        _possibleChanges --;

    }


}
