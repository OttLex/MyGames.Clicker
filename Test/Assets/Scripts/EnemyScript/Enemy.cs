using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :MonoBehaviour
{
    [SerializeField] protected int _hpCurrent;

    private GameManager _gameManager;

    //Эффект от получения урона
    [SerializeField] SpriteRenderer _sprite;
    private Color _damdgeMarker= new Color(1,.9f,.9f,1);
    private Color _addedTone = new Color(0, 0.1f, 0.1f, 0);
    private float _toneStep = 0.1f;

    private Camera _cam;
      

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        _cam = Camera.main;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit, 100))
            {

                if (_hit.collider.TryGetComponent(out EnemyMelee _enemy))
                {
                    _enemy.GetDamage();
                }
                else if (_hit.collider.TryGetComponent(out EnemyAgiled _enemyAgilled))
                {
                    _enemyAgilled.GetDamage();
                }


            }

        }
    }

    public virtual void GetDamage()
    {
        _hpCurrent--;
        _sprite.color = _damdgeMarker - _addedTone;
        _addedTone = new Color(0 , 0.1f+_toneStep, 0.1f+ _toneStep, 0);
        _toneStep += 0.1f;
        
        if (_hpCurrent <= 0)
        {
            _gameManager.StartCoroutine("EnemySpawn");
            _gameManager.AddScore();
            DestroyImmediate(this.gameObject);           
        }
    }
}
