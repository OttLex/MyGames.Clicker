using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  
    private static int _playerMaxHp=3;
    private int _playerCurrentHp;
    private static int _playerDamage=1;
    private static int _playerIncome=1;
    //UI
    [SerializeField]
    private Text _playerHpLabel;
    [SerializeField]
    private GameObject _gameOverLabel;
    private GameManager _gameManager;
   

    private void Start()
    {
        _playerCurrentHp = _playerMaxHp;
        _playerHpLabel.text = "Your HP: " + _playerCurrentHp.ToString();
        _gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    public void PlayerGetDamage(int enemyDamage)
    {
        _playerCurrentHp = _playerCurrentHp- enemyDamage;
        _playerHpLabel.text = "Your HP: " + _playerCurrentHp.ToString();
        if (_playerCurrentHp<= 0)
        {
            _gameManager.GameOver();
        }
    }
    public int PlayerDamage()
    {
        //отправляет текущий урон игрока противникам
        return _playerDamage;
    }
  
    //Методы магазина
    //Методы для улучшения характеристик в магазине
    public static int CurrentDamage()
    {
        return _playerDamage;
    }
    public static int CurrentMaxHp()
    {
        return _playerMaxHp;
    }
    public static int CurrentIncome()
    {
        return _playerIncome;
    }
    //Методы для улучшения характеристик в магазине
    public static void UpgradeDamage()
    {
        _playerDamage++;
    }
    public static void UpgradeMaxHp()
    {
        _playerMaxHp = _playerMaxHp + 2; ;
    }
    public static void UpgradeIncome()
    {
        _playerIncome++;
    }

}
