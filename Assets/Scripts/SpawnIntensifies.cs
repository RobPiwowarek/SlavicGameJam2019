﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIntensifies : MonoBehaviour
{
    //Array of objects to spawn (note I've removed the private goods variable)
    public GameObject[] theGoodies;

    public GameObject particle;

    public int numberSpawned = 2;
    
    //Time it takes to spawn theGoodies
    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
  
    // the range of X
    [Header ("X Spawn Range")]
    public float xMin;
    public float xMax;
  
    // the range of y
    [Header ("Y Spawn Range")]
    public float yMin;
    public float yMax;

    public void Update()
    {
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if(theCountdown <= 0)
        {
            SpawnGoodies ();
            theCountdown = waitingForNextSpawn;
        }
    }
  
  
    void SpawnGoodies()
    {
        for (int i = 0; i < numberSpawned; ++i)
        {

            // Defines the min and max ranges for x and y
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            // Choose a new goods to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
            GameObject goodsPrefab = theGoodies[Random.Range(0, theGoodies.Length)];

            // Creates the random object at the random 2D position.
            Instantiate(goodsPrefab, pos, Quaternion.identity);
            Instantiate(particle, pos, Quaternion.identity);

            // If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
            //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
            //newgoods.something = somethingelse;
        }

        numberSpawned++;
    }
}