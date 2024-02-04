using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ScoreHandler scoreHandler;
    public PhantomSpawn phantomSpawn;
    public GameObject gameOverPanel;
    private bool _isAngry;
    private TextMeshProUGUI _playerStatus;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _finalScoreText;

    private void Start()
    {
        Time.timeScale = 1;
        _isAngry = false;
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _finalScoreText = GameObject.Find("FinalScoreText").GetComponent<TextMeshProUGUI>();
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Food").Length == 0)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            string phantomName = other.gameObject.name;
            if (_isAngry)
            {
                Destroy(other.gameObject);
                scoreHandler.UpdateScore(20);
                StartCoroutine(SpawnPhantom(phantomName));
            }
            else
            {
                Destroy(gameObject);
                GameOver();
            }
        }
        
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            scoreHandler.UpdateScore(1);
        }

        if (other.gameObject.CompareTag("Pacgum"))
        {
            Destroy(other.gameObject);
            scoreHandler.UpdateScore(10);
            StartCoroutine(AngryMode());
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator AngryMode()
    {
        _isAngry = true;
        _playerStatus = GameObject.Find("PlayerStatus").GetComponent<TextMeshProUGUI>();
        _playerStatus.text = $"Angry Mode\nEat the phantoms";
        yield return new WaitForSeconds(8.0f);
        _isAngry = false;
        _playerStatus.text = $"Flee the phantoms and eat the food";
    }

    private IEnumerator SpawnPhantom(string phantomName)
    {
        yield return new WaitForSeconds(4);
        switch (phantomName)
        {
            case "Pinky":
                phantomSpawn.PinkySpawn();
                break;
            case "Blinky":
                phantomSpawn.BlinkySpawn();
                break;
            case "Inky":
                phantomSpawn.InkySpawn();
                break;
            case "Clyde":
                phantomSpawn.ClydeSpawn();
                break;
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _scoreText.enabled = false;
        gameOverPanel.SetActive(true);
        GameObject.Find("PlayerStatus").GetComponent<TextMeshProUGUI>().enabled = false;
        _finalScoreText.text = $"Your score : {scoreHandler.GetScore()}";
    }
}
