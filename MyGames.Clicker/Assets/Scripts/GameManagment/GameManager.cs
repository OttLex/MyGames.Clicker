using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Поля с параметрами для спавна
    [SerializeField] GameObject[] _enemyList;
    private Vector3 _spawnPosition = new Vector3(0, 0, 0);
    //Система очков и их отображения
    private int _score=0;
    [SerializeField] Text _scoreText;
    private static int _highScore;

    //Экономика
    private static int _coins=0;
    [SerializeField]

    
    //Таймер
    private float _time;
    [SerializeField] Text _timeText;

    //Конец игры
    [SerializeField]
    private Text _playerHpLabel;
    [SerializeField]
    private GameObject _gameOverLabel;
    [SerializeField] Text _gameOverTimer;
    [SerializeField] Text _gameOverScore;
    [SerializeField] Text _gameOverHighScore;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
        TimeReset();

    }
    private void FixedUpdate()
    {
        _time = Time.timeSinceLevelLoad;
        _timeText.text = _time.ToString();
    }

    public void TimeReset()
    {
        _time = 0f;
    }

    public float GetTime()
    {
        return _time;
    }

    public IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(.1f);
        int _chosenEnemy;
        if (_score > 10)
        {
            _chosenEnemy = Random.Range(0, _enemyList.Length);
        }
        else
        {
            _chosenEnemy = Random.Range(0, _enemyList.Length - 1);
        }
        Instantiate(_enemyList[_chosenEnemy], _spawnPosition, Quaternion.identity);
    }


    public void AddScore(int enemyScoreCost)
    {
        _score += enemyScoreCost;
        _coins += enemyScoreCost* PlayerController.CurrentIncome();
        _scoreText.text = "Score:" +_score;
        if (_score >= _highScore)
        {
            _highScore = _score;
        }
    }
    public static int GetCoinsValue()
    {
        return _coins;
    }
    public static void SetCoinsValue(int newCoinsValue)
    {
        _coins = newCoinsValue;
    }
    public int GetScore()
    {
        return _score;
    }
    public int GetHighScore()
    {
        return _highScore;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestarGame()
    {
        TimeReset();
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        StopAllCoroutines();
        var enemy = GameObject.FindGameObjectWithTag("Enemy");
        DestroyImmediate(enemy);
        _playerHpLabel.gameObject.SetActive(false);
        _gameOverLabel.SetActive(true);
        _gameOverTimer.text = "Your time: " + GetTime().ToString();
        _gameOverScore.text = "Your score: " + GetScore().ToString();
        _gameOverHighScore.text = "Your highscore: " + GetHighScore();
    }
}
