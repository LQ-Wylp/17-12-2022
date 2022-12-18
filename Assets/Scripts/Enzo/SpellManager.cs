using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SpellManager : MonoBehaviour
{
    public int _currentMana;
    private float _timerRegeneration;
    public int _timerDuration;
    public Spell[] _allSpells;
    private PlayerControls _playerControls;

    bool _canCast;

    private void Start() {
        _playerControls = new PlayerControls();
        _playerControls.Game.Enable();
        _playerControls.Game.A.performed += ctx => CastSpell(_allSpells[0]);
        _playerControls.Game.Z.performed += ctx => CastSpell(_allSpells[1]);
        _playerControls.Game.E.performed += ctx => CastSpell(_allSpells[2]);
        _playerControls.Game.R.performed += ctx => CastSpell(_allSpells[3]);
    }
    void Update()
    {
        _timerRegeneration -= Time.deltaTime;
        if (_timerRegeneration <= 0)
        {
            SpellRegeneration();
            _timerRegeneration = _timerDuration;
        }
    }

    void SpellRegeneration()
    {
        _currentMana++;
    }
    public bool CheckCastability(Spell spellToCheck)
    {
        if (spellToCheck._cost <= _currentMana)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void CastSpell(Spell spellToCast)
    {
        if(CheckCastability(spellToCast))
        {
            spellToCast.Cast();
            _currentMana = _currentMana - spellToCast._cost;
        }
    }
    




}
