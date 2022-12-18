using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpell : Spell
{
    private Tower[] _allTower;
    
    [SerializeField] MonsterManager _monsterManager;
    private void Start()
    {
        _allTower = GameObject.FindObjectsOfType<Tower>();
        _monsterManager = GameObject.FindObjectOfType<MonsterManager>();
    }
    public override void CastEffect()
    {

        for (int i = 0; i < _allTower.Length; i++)
        {
            _allTower[i]._isSlowed = true;
        }
        for (int i = 0; i < _monsterManager.MonstersAlive.Count; i++)
        {
            _monsterManager.MonstersAlive[i].GetComponent<EnemyMovement>().isSpeed = true;
        }

    }
}
