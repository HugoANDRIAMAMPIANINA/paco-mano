using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ScoreHandler scoreHandler;
    public PhantomSpawn phantomSpawn;
    private bool _isAngry = false;
    private TextMeshProUGUI _playerStatus;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            string phantomName = other.gameObject.name;
            Destroy(_isAngry ? other.gameObject : gameObject);
            StartCoroutine(SpawnPhantom(phantomName));
        }
        
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            scoreHandler.UpdateScore(1);
        }

        if (other.gameObject.CompareTag("Pacgum"))
        {
            Destroy(other.gameObject);
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
}
