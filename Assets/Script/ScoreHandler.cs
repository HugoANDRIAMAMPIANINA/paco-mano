using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    private int _score;
    private TextMeshProUGUI _scoreText;
    
    void Start()
    {
        _score = 0;
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _scoreText.text = $"Score : {_score}";
    }

    public int GetScore()
    {
        return _score;
    }

    public void UpdateScore(int scoreToAdd) 
    {
        _score += scoreToAdd;
        _scoreText.text = $"Score : {_score}";
    }
}
