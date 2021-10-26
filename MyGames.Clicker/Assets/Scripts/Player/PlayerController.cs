using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _playerHp;
    [SerializeField]
    private Text _playerHpLabel;
    [SerializeField]
    private GameObject _gameOverLabel;
    private GameManager _gameManager;
   

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    public void PlayerGetDamage(int enemyDamage)
    {
        _playerHp = _playerHp- enemyDamage;
        _playerHpLabel.text = "Your HP: " + _playerHp.ToString();
        if (_playerHp<= 0)
        {
            _gameManager.GameOver();
        }
    }

    
}
