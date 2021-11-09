using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGameManager : GameManager
{
  
    public override void SetTime()
    {
        if (_time > 0) {
            _time -= Time.deltaTime;
            _timeText.text = _time.ToString();
            if (_time <= 0)
            {
                _time =0;
                _timeText.text = _time.ToString();
                GameOver();
            }
        }
    }
   
}
