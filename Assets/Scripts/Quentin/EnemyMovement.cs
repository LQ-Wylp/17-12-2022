using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float percentLerp;

    private Transform point_1;
    private Transform point_2;

    private Path path;

    private int i;

    public float DistanceParcourue;
    private int NbPointAtteins;

    public GameObject Visuel;

    // Start is called before the first frame update
    void Start()
    {
        DistanceParcourue = 0;
        path = FindObjectOfType<Path>();

        point_1 = path.listTransform[0];
        point_2 = path.listTransform[1];
        transform.position = Vector3.Lerp(point_1.position, point_2.position, percentLerp);

        Visuel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        percentLerp += speed * Time.deltaTime / Vector3.Distance(point_1.position, point_2.position);

        transform.position = Vector3.Lerp(point_1.position, point_2.position, percentLerp);


        if (percentLerp > 1) { percentLerp = 1; }
        DistanceParcourue = percentLerp + NbPointAtteins;

        if (percentLerp >= 1 && i <= path.listTransform.Count - 3) // -3 pour l'index, l'incrémation et le +1
        {
            percentLerp = 0;

            i++;
            NbPointAtteins++;

            point_1 = path.listTransform[i];
            point_2 = path.listTransform[i + 1];
        }

        else if (percentLerp >= 1)
        {
            //Ennemy passe
        }
    }
}
