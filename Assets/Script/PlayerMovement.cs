using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 _direction = Vector2.zero;
    private Vector2 _lastDirection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }

        Move();
    }

    void Move()
    {
        transform.localPosition += (Vector3)(_direction * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _lastDirection = _direction;
            _direction = Vector2.zero;
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (_lastDirection == _direction)
            {
                _direction = Vector2.zero;
            }
        }
    }
}
