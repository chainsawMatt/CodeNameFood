using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] Toppings;
    public float secondsBetweenSpawns = 1;
    float nextSpawnTime;
    int randomInt;
  
    Vector2 screenHalfsizeWorldUnits;

    // Use this for initialization
    void Start()
    {
        screenHalfsizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            SpawnRandom();
        }
    }
    void SpawnRandom()
    {
      randomInt = Random.Range(0, Toppings.Length);
      Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfsizeWorldUnits.x +120, screenHalfsizeWorldUnits.x), screenHalfsizeWorldUnits.y - 5);
    
      Instantiate(Toppings[randomInt], spawnPosition, Quaternion.identity);
    
    }

}

