using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapEnnemySpell : Spell
{
    [SerializeField] MonsterManager _monsterManager;
    public List<GameObject> MonstreAliveInverse;
    private void Start()
    {
        _monsterManager = GameObject.FindObjectOfType<MonsterManager>();
        MonstreAliveInverse = new List<GameObject>();
    }

    public override void CastEffect()
    {
        MonstreAliveInverse.Clear();
        for (int i = _monsterManager.MonstersAlive.Count - 1; i >= 0; i--)
        {
            MonstreAliveInverse.Add(_monsterManager.MonstersAlive[i]);


        }

        for (int j = 0; j < _monsterManager.MonstersAlive.Count; j++)
        {
            EnemyMovement EM1 = _monsterManager.MonstersAlive[j].gameObject.GetComponent<EnemyMovement>();
            EnemyMovement EM2 = MonstreAliveInverse[j].gameObject.GetComponent<EnemyMovement>();
            EnemyMovement EmStock = EM1;


            EM2.i = EmStock.i;
            EM2.NbPointAtteins = EmStock.NbPointAtteins;
            EM2.percentLerp = EmStock.percentLerp;
            EM2.DistanceParcourue = EmStock.DistanceParcourue;
            EM2.RefreshPoint();

            EM1.i = EM2.i;
            EM1.NbPointAtteins = EM2.NbPointAtteins;
            EM1.percentLerp = EM2.percentLerp;
            EM1.DistanceParcourue = EM2.DistanceParcourue;
            EM1.RefreshPoint();
        }
    }

}
