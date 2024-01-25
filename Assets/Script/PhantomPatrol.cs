using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhantomPatrol : MonoBehaviour
{
    private Transform[] _waypoints;
    private int _currentWaypointIndex;
    private float _speed = 2f;

    private void Start()
    {
        _currentWaypointIndex = 0;
        SetWaypoints();
    }

    private void Update()
    {
        Transform wp = _waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) == 0)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, (_speed * Time.deltaTime));
        }
    }

    private void SetWaypoints()
    {
        GameObject[] gameObjects;
        if (gameObject.name == "Pinky")
        {
            gameObjects = GameObject.FindGameObjectsWithTag("PinkyWaypoint");
        } else if (gameObject.name == "Blinky")
        {
            gameObjects = GameObject.FindGameObjectsWithTag("BlinkyWaypoint");
        } else if (gameObject.name == "Clyde")
        {
            gameObjects = GameObject.FindGameObjectsWithTag("ClydeWaypoint");
        } else {
            gameObjects = GameObject.FindGameObjectsWithTag("InkyWaypoint");
        }

        _waypoints = new Transform[gameObjects.Length];
        for (var i = 0; i < gameObjects.Length; i++)
        {
            _waypoints[i] = gameObjects[i].transform;
        }
    }
}
