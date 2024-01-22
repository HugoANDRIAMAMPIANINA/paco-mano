using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomSpawn : MonoBehaviour
{
    public GameObject pinkyPrefab;
    public GameObject clydePrefab;
    public GameObject inkyPrefab;
    public GameObject blinkyPrefab;

    public void PinkySpawn()
    {
        GameObject phantom = Instantiate(pinkyPrefab);
        phantom.name = "Pinky";
    }
    
    public void ClydeSpawn()
    {
        GameObject phantom = Instantiate(clydePrefab);
        phantom.name = "Clyde";
    }
    
    public void BlinkySpawn()
    {
        GameObject phantom = Instantiate(blinkyPrefab);
        phantom.name = "Blinky";
    }
    
    public void InkySpawn()
    {
        GameObject phantom = Instantiate(inkyPrefab);
        phantom.name = "Inky";
    }
}
