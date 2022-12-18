using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapEnnemySpell : Spell
{
    [SerializeField] MonsterManager _monsterManager;

     private void Start()
    {
       
        _monsterManager = GameObject.FindObjectOfType<MonsterManager>();
    }

    public override void CastEffect()
    {

        for (int i = 0; i < _monsterManager.MonstersAlive.Count; i++)
        {
            _monsterManager.MonstersAlive[i].GetComponent<EnemyMovement>().isSpeed = true;
        }

    }
}
