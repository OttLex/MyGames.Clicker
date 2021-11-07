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
            transform.position = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        }
        else
        {
            base.GetDamage(playerDamage);
        }

    }

}

    
           
