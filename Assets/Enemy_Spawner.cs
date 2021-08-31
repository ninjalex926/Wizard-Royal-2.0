using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject enemy1;

    public GameObject enemy2;

    public int enemyCount;

    private int enemyToSpawn;

    [Tooltip("The current time of the Timer")]
    // The any given current time of the timer
    public float enemySpawnerCurrentTime = 0f;

    [Tooltip("The Start time of the timer")]
    // The default starting time of the timer
    public float startingEnemySpawnerCurrentTime = 10f;


    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerCurrentTime = startingEnemySpawnerCurrentTime;
    }

    // Update is called once per frame
    void Update()
    {   
        if (startingEnemySpawnerCurrentTime <= 0)
        {
           // Timer count down
           enemySpawnerCurrentTime-= 1 * Time.deltaTime;
        }
    }
}
