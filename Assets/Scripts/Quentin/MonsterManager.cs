using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager _MonsterManager;
    public List<GameObject> MonstersAlive;
    void Awake()
    {
        if (MonsterManager._MonsterManager == null)
        {
            MonsterManager._MonsterManager = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void addMonsterAlive(GameObject Monstre)
    {
        MonstersAlive.Add(Monstre);
    }
    public void removeMonsterAlive(GameObject Monstre)
    {
        MonstersAlive.Remove(Monstre);
    }

    public void TriMonstre_DistanceParcourue()
    {
        for (int i = 0; i < MonstersAlive.Count; i++)
        {
            buller();
        }
    }

    void Update()
    {
        TriMonstre_DistanceParcourue();
    }

    void echanger(int IndexA, int IndexB) // Testé
    {
        GameObject Copie = MonstersAlive[IndexA]; //Permet de garder une copie temporaire
        MonstersAlive[IndexA] = MonstersAlive[IndexB];
        MonstersAlive[IndexB] = Copie;
    }

    void buller() // Testé
    {
        for (int i = 0; i < MonstersAlive.Count; i++)
        {
            int Index = i;
            int IndexSuivant = i + 1;
            if (IndexSuivant < MonstersAlive.Count &&
            MonstersAlive[Index].gameObject.GetComponent<EnemyMovement>().DistanceParcourue < MonstersAlive[IndexSuivant].gameObject.GetComponent<EnemyMovement>().DistanceParcourue)
            {
                echanger(Index, IndexSuivant);
            }
        }
    }

}
