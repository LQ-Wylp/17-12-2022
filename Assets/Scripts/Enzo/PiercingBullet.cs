using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingBullet : MonoBehaviour
{
     public int degats;
    public float vitesse;
    public GameObject cible_bullet;
    private Rigidbody2D _rb;
    private Vector3 positionInitiale;
    private Vector2 _direction;
    //[SerializeField] bool _isPiercing;
    void Start()
    {
        positionInitiale = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        //_direction = (cible_bullet.transform.position - transform.position) * vitesse;
    }

    
    void Update()
    {
        if (cible_bullet == null)
        {
            Destroy(gameObject);
        }
        else
        {
            // pourcentage += Time.deltaTime * vitesse / Vector3.Distance(transform.position, cible_bullet.transform.position);
            // transform.position = Vector3.Lerp(transform.position, cible_bullet.transform.position, pourcentage);
            _direction = (cible_bullet.transform.position - transform.position).normalized * vitesse;
            _rb.velocity =  _direction;          
        }
    }

    // public void toucher()
    // {
    //     cible_bullet.GetComponent<HealthSystem>().PrendreDPS(degats);
    //     Destroy(gameObject);
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ennemy")
        {
            other.GetComponent<HealthSystem>().PrendreDPS(degats);
        }
        if(other.name == "Target")
        {
            Destroy(gameObject);
        }
    }

    public void setCibleBullet(GameObject cible)
    {
        cible_bullet = cible;
    }
}
