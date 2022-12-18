using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float rapidSpeed;
    float normalSpeed;
    public bool isSpeed;
    public float percentLerp;

    private Transform point_1;
    private Transform point_2;

    private Path path;

    public int i;

    public float DistanceParcourue;
    public int NbPointAtteins;

    public GameObject Visuel;
    [SerializeField] float _slowedTimer;
    float _timerSlow;

    // Start is called before the first frame update
    void Start()
    {
        DistanceParcourue = 0;
        path = FindObjectOfType<Path>();

        normalSpeed = speed;

        point_1 = path.listTransform[0];
        point_2 = path.listTransform[1];
        transform.position = Vector3.Lerp(point_1.position, point_2.position, percentLerp);

        Visuel.SetActive(true);
    }

    public void RefreshPoint()
    {
        point_1 = path.listTransform[i];
        point_2 = path.listTransform[i + 1];
    }

    // Update is called once per frame
    void Update()
    {
        percentLerp += speed * Time.deltaTime / Vector3.Distance(point_1.position, point_2.position);

        transform.position = Vector3.Lerp(point_1.position, point_2.position, percentLerp);


        if (percentLerp > 1) { percentLerp = 1; }
        DistanceParcourue = percentLerp + NbPointAtteins;

        if (percentLerp >= 1 && i <= path.listTransform.Count - 3) // -3 pour l'index, l'incr�mation et le +1
        {
            percentLerp = 0;

            i++;
            NbPointAtteins++;

            point_1 = path.listTransform[i];
            point_2 = path.listTransform[i + 1];
            //ia inv
            //nb pt a inv
            //distance parcouru a inv
            //percentLerp a inv
        }

        else if (percentLerp >= 1)
        {
            //Ennemy passe
        }

         if(isSpeed)
        {
            _timerSlow -= Time.deltaTime;
            speed = rapidSpeed;
        }

        if(_timerSlow <= 0)
        {
            speed = normalSpeed;
            isSpeed = false;
            _timerSlow = _slowedTimer;   
        }


    }

    
}
