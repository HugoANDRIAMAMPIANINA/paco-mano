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
        phantom.transform.position = new Vector3(-7.7f, 7f);
    }
    
    public void ClydeSpawn()
    {
        GameObject phantom = Instantiate(clydePrefab);
        phantom.name = "Clyde";
        phantom.transform.position = new Vector3(7.7f, -7f);
    }
    
    public void BlinkySpawn()
    {
        GameObject phantom = Instantiate(blinkyPrefab);
        phantom.name = "Blinky";
        phantom.transform.position = new Vector3(-7.7f, -7f);
    }
    
    public void InkySpawn()
    {
        GameObject phantom = Instantiate(inkyPrefab);
        phantom.name = "Inky";
        phantom.transform.position = new Vector3(7.7f, 7f);
    }
}
