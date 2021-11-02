using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgiled : Enemy
{
    [SerializeField] GameObject _blinkEffect;

    public override void GetDamage(int playerDamage)
    {
       
        //Шанс уклониться от атаки
        int _dodgeChance = 0;
        int rand = Random.Range(0, 3);
        if (_dodgeChance == rand)
        {
            Instantiate(_blinkEffect, transform.position, Quaternion.identity);
        }
        else
        {
            base.GetDamage(playerDamage);
        }

    }

}

    
           
