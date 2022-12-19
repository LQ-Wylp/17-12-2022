using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Tower : MonoBehaviour
{
    [SerializeField] float _cadence;
    [SerializeField] float _slowedCadence;
    [SerializeField] float _range;
    [SerializeField] int _damage;
    [SerializeField] GameObject _bullet;
    private GameObject _target;
    private float _originCadence;
    [SerializeField] GameObject _targetRenderer;
    private MonsterManager _monsterManager;


    public BaseTower _origin;
    public BaseTower _hoveredBase;
    public bool _qqunPrisPasMoi;
    public bool _taken;
    public bool _canBeTaken;
    public bool _isSlowed;

    private FollowMouse _cursor;
    float _timer;
    public SelectionManager _selectionManager;
    bool _canShoot = true;

    [SerializeField] float _slowedTimer;
    float _timerSlow;

    private void Start()
    {
        _cursor = GameObject.FindObjectOfType<FollowMouse>();
        transform.position = _origin.transform.position;
        _origin._isEmpty = false;
        _origin._tower = this;
        _monsterManager = GameObject.FindObjectOfType<MonsterManager>();
        _targetRenderer.transform.localScale = new Vector2(_range * 1.5f, _range * 1.5f);
        _originCadence = _cadence;
        _timerSlow = _slowedTimer;
    }

    void Update()
    {
        if (_canBeTaken && Mouse.current.leftButton.IsPressed() && !_qqunPrisPasMoi && _selectionManager._possibleChanges > 0)
        {
            TakeObject();
        }

        if (!Mouse.current.leftButton.IsPressed())
        {
            _qqunPrisPasMoi = false;
        }


        if (_taken && !Mouse.current.leftButton.IsPressed())
        {
            if (_hoveredBase != null)
            {
                if (_hoveredBase._isEmpty)
                {
                    _selectionManager.MePlacerSurUnSocleVide(this);

                }
                else if (!_hoveredBase._isEmpty && _hoveredBase != _origin)
                {
                    Tower t1 = this;
                    Tower t2 = _hoveredBase._tower;

                    _selectionManager.EchangerDeuxTours(t1, t2);
                }
                else if(!_hoveredBase._isEmpty && _hoveredBase == _origin)
                {
                    _selectionManager.MePlacerSurUnSocleVide(this);
                }
            }
           
            else
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


        if(_isSlowed)
        {
            _timerSlow -= Time.deltaTime;
            _cadence = _slowedCadence;
        }

        if(_timerSlow <= 0)
        {
            _cadence = _originCadence;
            _isSlowed = false;
            _timerSlow = _slowedTimer;   
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
        _taken = true;

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
        if (other.GetComponent<BaseTower>() != null)
        {
            _hoveredBase = other.GetComponent<BaseTower>();
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
        }

    }

}
