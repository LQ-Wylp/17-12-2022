using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Syst�me de vies")]
    public int VieInitiale;
    private int VieRestante;


    // Start is called before the first frame update
    void Start()
    {
        VieRestante = VieInitiale;
    }
    void Update()
    {
        if (VieRestante <= 0)
        {
            DestroyThis();
        }
    }
    public void PrendreDPS(int DommageSubit)
    {
        VieRestante -= DommageSubit;
       
    }

    public void DestroyThis()
    {
        MonsterManager._MonsterManager.removeMonsterAlive(this.gameObject);
        Destroy(this.gameObject);
    }


}
