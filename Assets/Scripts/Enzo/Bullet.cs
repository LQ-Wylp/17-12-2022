using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int degats;
    public float vitesse;
    private GameObject cible_bullet;
    private float pourcentage;
    private Vector3 positionInitiale;
    //[SerializeField] bool _isPiercing;
    void Start()
    {
        positionInitiale = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cible_bullet == null)
        {
            Destroy(gameObject);
        }
        else
        {
            pourcentage += Time.deltaTime * vitesse / Vector3.Distance(transform.position, cible_bullet.transform.position);
            transform.position = Vector3.Lerp(transform.position, cible_bullet.transform.position, pourcentage);

            if (pourcentage >= 1f)
            {
                toucher();
            }
        }
    }

    public void toucher()
    {
        cible_bullet.GetComponent<HealthSystem>().PrendreDPS(degats);
        Destroy(gameObject);
    }

    public void setCibleBullet(GameObject cible)
    {
        cible_bullet = cible;
    }
}
