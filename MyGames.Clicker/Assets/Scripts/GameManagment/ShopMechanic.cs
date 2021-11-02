using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMechanic : MonoBehaviour
{
    [SerializeField] private Text _currentCoins;
    [SerializeField] private Text _hpCost;
    [SerializeField] private Text _damageCost;
    [SerializeField] private Text _incomeCost;

    void Start()
    {
        UpdateUI();
    }

   
    public void UpdateUI()
    {
        _currentCoins.text = GameManager.GetCoinsValue().ToString();
        _hpCost.text = CalculateCost(PlayerController.CurrentMaxHp()).ToString();
        _damageCost.text = CalculateCost(PlayerController.CurrentDamage()).ToString();
        _incomeCost.text = CalculateCost(PlayerController.CurrentIncome()).ToString();
    }

    public void UpgradeHpButton()
    {
        var value = CalculateCost(PlayerController.CurrentMaxHp());
        var cost = CalculateCost(value);
        if (CheckCost(cost))
        {
            var newCoinsValue = GameManager.GetCoinsValue() - cost;
            GameManager.SetCoinsValue(newCoinsValue);
            PlayerController.UpgradeMaxHp();
            UpdateUI();
        }
    }
    public void UpgradeDamageButton()
    {
        var value = CalculateCost(PlayerController.CurrentDamage());
        var cost = CalculateCost(value);
        if (CheckCost(cost))
        {
            var newCoinsValue = GameManager.GetCoinsValue() - cost;
            GameManager.SetCoinsValue(newCoinsValue);
            PlayerController.UpgradeDamage();
            UpdateUI();
        }
    }
    public void UpgradeIncomeButton()
    {
        var value = CalculateCost(PlayerController.CurrentIncome());
        var cost = CalculateCost(value);
        
        if (CheckCost(cost))
        {
            var newCoinsValue = GameManager.GetCoinsValue() - cost;
            GameManager.SetCoinsValue(newCoinsValue);
            PlayerController.UpgradeIncome();
            UpdateUI();
        }
    }


    public int CalculateCost(int value)
    {
        return value;
    }

    public bool CheckCost(int cost)
    {
        if (cost <= GameManager.GetCoinsValue())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
