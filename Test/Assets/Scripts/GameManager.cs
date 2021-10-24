using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Поля с параметрами для спавна
    [SerializeField] GameObject[] _enemyList;
    private Vector3 _spawnPosition = new Vector3(0, 0, 0);
    //Система очков и их отображения
    private int _score=0;
    [SerializeField] Text _scoreText;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    public IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(.1f);
        var _chosenEnemy = Random.Range(0, _enemyList.Length);
        Instantiate(_enemyList[_chosenEnemy], _spawnPosition, Quaternion.identity);
    }


    public void AddScore()
    {
        _score += 1;
        _scoreText.text = "Score:" +_score ;
    }
}
