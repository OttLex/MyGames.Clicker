using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy :MonoBehaviour
{

    private Camera _cam;
    private GameManager _gameManager;
    [SerializeField]
    private int _enemyScoreCost;

    //Эффект от получения урона
    [SerializeField] SpriteRenderer _sprite;
    private Color _damdgeMarker= new Color(1,.9f,.9f,1);
    private Color _addedTone = new Color(0, 0.1f, 0.1f, 0);
    private float _toneStep = 0.1f;

    [SerializeField]
    private EnemyHeathbar _enemyHeathbar;

    //Параметры атаки
    private PlayerController _player;
    [SerializeField]
    private int _enemyDamage;
    [SerializeField]
    private float _timeToAttack;
    [SerializeField] protected int _hpCurrent;
    [SerializeField] private int _hpMax;
    private Animator _animator;
    [SerializeField] private AudioClip _attackSound;
    private AudioSource _audioSource;
      

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        _cam = Camera.main;
        _animator = GetComponentInChildren<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        int hpProgression= _gameManager.GetScore()/4;
        int damageProgression = _gameManager.GetScore() / 8;
        _hpMax += hpProgression;
        _enemyDamage += damageProgression;
        _hpCurrent = _hpMax;
        _enemyHeathbar.SetHealth(_hpCurrent, _hpMax);
         _audioSource= GetComponent<AudioSource>();
        _audioSource.clip = _attackSound;
        StartCoroutine(EnemyAttack());

    }

    private void Update()
    {

        //Обработка инпута для получения урона
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit, 100))
            {

                if (_hit.collider.TryGetComponent(out Enemy _enemy))
                {
                    _enemy.GetDamage(_player.PlayerDamage());
                }
               
            }

        }
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(_timeToAttack-0.5f);
        _animator.SetTrigger("Attack");
        _audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        _player.PlayerGetDamage(_enemyDamage);        
        StartCoroutine(EnemyAttack());
    }

    public virtual void GetDamage(int playerDamage)
    {
        //Метод для получения урона 
        _hpCurrent-= playerDamage;
        _sprite.color = _damdgeMarker - _addedTone;
        _addedTone = new Color(0 , 0.1f+_toneStep, 0.1f+ _toneStep, 0);
        _toneStep += 0.1f;
        _enemyHeathbar.SetHealth(_hpCurrent, _hpMax);

        if (_hpCurrent <= 0)
        {
            _gameManager.StartCoroutine("EnemySpawn");
            _gameManager.AddScore(_enemyScoreCost );
            DestroyImmediate(this.gameObject);           
        }
    }
}
