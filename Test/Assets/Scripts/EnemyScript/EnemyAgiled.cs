using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgiled : Enemy
{
    [SerializeField] GameObject _blinkEffect;

    public override void GetDamage()
    {
       
        //Шанс уклониться от атаки
        int _dodgeChance = 0;
        int rand = Random.Range(0, 3);
        if (_dodgeChance == rand)
        {
            transform.position = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(3f, -3f));
            Instantiate(_blinkEffect, transform.position, Quaternion.identity);
        }
        else
        {
            base.GetDamage();
        }

    }

}

    
           
