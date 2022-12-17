using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<GameObject> ListeMonstres;

    public int Nb_Monstre_Restant;
    public float Temps_Intervale_Monstre;

    private float Temps;

    private bool activate = false;

    private bool finish = false;

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            Temps += Time.deltaTime;
            if (Temps >= Temps_Intervale_Monstre && Nb_Monstre_Restant >= 1)
            {
                Temps = 0;
                ApparaitreMonstre();

                if (Nb_Monstre_Restant <= 0)
                {
                    finish = true;
                    activate = false;
                }
            }
        }
    }

    public void ApparaitreMonstre()
    {
        Nb_Monstre_Restant--;
        GameObject MonstreAleatoire = ListeMonstres[Random.Range(0, ListeMonstres.Count)];
        GameObject NewMonster = Instantiate(MonstreAleatoire, Vector3.zero, Quaternion.identity);
        MonsterManager._MonsterManager.addMonsterAlive(NewMonster);
    }

    public void setActivate(bool etat)
    {
        this.activate = etat;
    }

    public bool getFinish()
    {
        return finish;
    }

    public int getActualMonsterNumber()
    {
        return Nb_Monstre_Restant;
    }
}
