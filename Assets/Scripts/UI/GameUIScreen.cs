using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIScreen : UIScreen
{
    private ResultSystem _resultSystem;
    private int[] _scores;
    private GameScoreShower _gameScore;

    private void Start()
    {
        _resultSystem = FindObjectOfType<ResultSystem>();
        _resultSystem.OnGameEnd += SwitchScreen;
        _gameScore = GetComponent<GameScoreShower>();
    }

    private void GetScore()
    {
        _scores = _gameScore.GetScore();
    }

    protected override void SwitchScreen()
    {
        GetScore();
        _resultSystem.OnGameEnd -= SwitchScreen;
        _nextScreen.Init(_scores[0], _scores[1], _scores[2]);
        base.SwitchScreen();
    }
}
