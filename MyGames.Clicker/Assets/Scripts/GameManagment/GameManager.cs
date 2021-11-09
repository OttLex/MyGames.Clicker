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
    protected float _time;
    [SerializeField] protected Text _timeText;

    //Конец игры
    [SerializeField] private Button _exitBitton;
    [SerializeField]
    private Text _playerHpLabel;
    [SerializeField]
    private GameObject _gameOverLabel;
    [SerializeField] private Text _gameOverTimer;
    [SerializeField] private Text _gameOverScore;
    [SerializeField] private Text _gameOverHighScore;
    [SerializeField] private AudioClip _loseSound;
    private AudioSource _audioSource;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
        _audioSource= GetComponent<AudioSource>();
   

    }
    private  void FixedUpdate()
    {
        SetTime();
    }
  
    public float GetTime()
    {
        return _time;
    }

    public virtual void SetTime()
    {
        _time = Time.timeSinceLevelLoad;
        _timeText.text = _time.ToString();
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

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        StopAllCoroutines();
        var enemy = GameObject.FindGameObjectWithTag("Enemy");
        DestroyImmediate(enemy);
        _audioSource.volume = 0.2f;
        _audioSource.PlayOneShot(_loseSound);
        _exitBitton.gameObject.SetActive(false);
        _playerHpLabel.gameObject.SetActive(false);
        _gameOverLabel.SetActive(true);
        _gameOverScore.text = "Your score: " + GetScore().ToString();
        _gameOverHighScore.text = "Your highscore: " + GetHighScore();
        if (_time > 0)
        {
            _gameOverTimer.text = "Your time: " + GetTime().ToString();
        }
    }
}
