using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Tower : MonoBehaviour
{
    [SerializeField] float _cadence;
    [SerializeField] float _range;
    [SerializeField] int _damage;
    [SerializeField] GameObject _bullet;
    private GameObject _target;

    [SerializeField] GameObject _targetRenderer;
    private MonsterManager _monsterManager;
    [SerializeField] BaseTower _origin;
    private BaseTower _hoveredBase;
    public bool _qqunPrisPasMoi;
    private bool _taken;
    private bool _canBeTaken;
    private FollowMouse _cursor;
    bool _canBePlaced;
    float _timer;
    public SelectionManager _selectionManager;
    bool _canShoot;

    private void Start()
    {
        _cursor = GameObject.FindObjectOfType<FollowMouse>();
        transform.position = _origin.transform.position;
        _origin._isEmpty = false;
        _origin._tower = this;
        _monsterManager = GameObject.FindObjectOfType<MonsterManager>();
        _targetRenderer.transform.localScale = new Vector2(_range * 1.5f, _range * 1.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up);
    }


    void Update()
    {
        if (_canBeTaken && Mouse.current.leftButton.IsPressed() && !_qqunPrisPasMoi)
        {
            TakeObject();
        }

        if (_taken && !Mouse.current.leftButton.IsPressed())
        {
            if (_canBePlaced && _hoveredBase._isEmpty)
            {
                _origin = _hoveredBase;
                transform.position = _origin.transform.position;
                _hoveredBase._isEmpty = false;
                _hoveredBase._tower = this;
                
                _selectionManager.AuSuivant();

            }
            // else if (_canBePlaced && !_hoveredBase._isEmpty)
            // {
            //     ChangeOrigin();
            //     //_hoveredBase._tower._origin = _origin;
            //     // _hoveredBase._tower.transform.position = _hoveredBase._tower._origin.transform.position;
            //     // _origin._isEmpty = false;
            //     // transform.position = _hoveredBase.transform.position;
            //     // _hoveredBase._isEmpty = false;
            //     // _hoveredBase._tower = this;
            //     // _origin = _hoveredBase;
            //     _selectionManager.AuSuivant();


            // }
            else if (!_canBePlaced)
            {
                transform.position = _origin.transform.position;
            }
            _taken = false;

        }

        // DefinirCible();
        _timer -= Time.deltaTime;
        if (_timer <= 0 && !_taken && _canShoot)
        {
            SpawnBullet();
            _timer = _cadence;
        }

        // if (_target != null)
        //     ShootTarget();

        //_target = _monsterManager.MonstersAlive[0];

    }
    void SpawnBullet()
    {
        DefinirCible();
        if (_target != null)
        {
            GameObject mon_nouveau_missile = Instantiate(_bullet, transform.position, Quaternion.identity); //Quaternion.identity = angle 
            mon_nouveau_missile.GetComponent<Bullet>().setCibleBullet(_target);
            mon_nouveau_missile.SetActive(true);
        }
    }
    // void ChangeOrigin()
    // {

    //     BaseTower socle1 = _origin;
    //     BaseTower socle2 = _hoveredBase._tower._origin;
    //     Vector2 pos1 = _origin.transform.position;
    //     Vector2 pos2 = _hoveredBase._tower._origin.transform.position;

    //     if(_hoveredBase != _origin)
    //     {
    //     transform.position = _hoveredBase.transform.position;
    //     _hoveredBase._tower.transform.position = _origin.transform.position;
    //     _origin = socle2;
    //     _hoveredBase._tower._origin = socle1;
    //     }
    //     else
    //     {
    //         transform.position = _origin.transform.position;
    //     }
    //     Debug.Log("ahahahaha");
        
    // }
    bool etre_a_portee()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) <= _range)
        {
            return true;
        }
        return false;
    }
    public void DefinirCible()
    {
        List<GameObject> Monsters = MonsterManager._MonsterManager.MonstersAlive;
        for (int i = 0; i < Monsters.Count; i++)
        {
            _target = Monsters[i];
            if (etre_a_portee())
            {
                return;
            }
            else
            {
                _target = null;
            }
        }
    }

    void TakeObject() //D�tecte si un objet est plac� � l'endroit o� l'utilisateur pointe la souris
    {
        // Tower[] allTower = GameObject.
        _taken = true;
        // _hasAnObject = true;
        transform.position = _cursor.transform.position;
        _selectionManager.PrendreUnePersonne(this);

    }
    IEnumerator StopTurretCoroutine()
    {
        _canShoot = false;
        yield return new WaitForSeconds(4);
        _canShoot = true;
    }
    void StopTurret()
    {
        StartCoroutine(StopTurretCoroutine());
    }
    // void ShootTarget()
    // {
    //     _timer -= Time.deltaTime;
    //     if (_timer <= 0)
    //     {
    //         _target.GetComponent<HealthSystem>().PrendreDPS(_damage);
    //         _timer = _cadence;
    //     }

    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "cursor")
        {
            _canBeTaken = true;
        }
        if (other.GetComponent<BaseTower>() != null && !other.GetComponent<BaseTower>()._isEmpty)
        {
            _hoveredBase = other.GetComponent<BaseTower>();
            _canBePlaced = false;
        }
        else if(other.GetComponent<BaseTower>() != null && other.GetComponent<BaseTower>()._isEmpty)
        {
            _hoveredBase = other.GetComponent<BaseTower>();
            _canBePlaced = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "cursor")
        {
            _canBeTaken = false;
        }
        if (other.GetComponent<BaseTower>() != null)
        {
            _hoveredBase = null;
            _canBePlaced = false;
        }

    }

}
