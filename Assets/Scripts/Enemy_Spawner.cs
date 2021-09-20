using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    public GameObject waveMannager;

    public GameObject enemy1;

    public GameObject enemy2;

    public int enemyCount;

    private int enemyToSpawn;

    public bool connectWave;

    private int waveGoal;

    [Tooltip("The current time of the Timer")]
    // The any given current time of the timer
    public float spawnerCurrentTime = 0f;

    [Tooltip("The Start time of the timer")]
    // The default starting time of the timer
    public float startingSpawnerTime = 10f;


    // Start is called before the first frame update
    void Start()
    {
        if (connectWave)
        {
            waveMannager = GameObject.FindGameObjectWithTag("WaveManager");
            waveGoal = waveMannager.GetComponent<EnemyWaveManager>().waveKCGoal;
        }

        spawnerCurrentTime = startingSpawnerTime;

        print(spawnerCurrentTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnerCurrentTime > 0)
        {
            // Timer count down
            spawnerCurrentTime -= 1 * Time.deltaTime;
        }


        // Is connected to Wave Manager
        if (connectWave)
        {
            if (enemyCount < waveGoal)
            {
                if (spawnerCurrentTime <= 0)
                {

                    enemyToSpawn = Random.Range(0, 2);

                    switch(enemyToSpawn)
                    {
                        case 0:
                            Instantiate(enemy1, transform.position, transform.rotation);
                            ++enemyCount;
                            spawnerCurrentTime = startingSpawnerTime;
                            break;

                        case 1:
                            Instantiate(enemy2, transform.position, transform.rotation);
                            ++enemyCount;
                            spawnerCurrentTime = startingSpawnerTime;
                            break;

                        default:
                            break;

                    }                                                                 
                }
            }
        }
        else
        {
            // Not Connctd to Wave Manager
            if (spawnerCurrentTime <= 0)
            {
                Instantiate(enemy1, transform.position, transform.rotation);
                ++enemyCount;
                spawnerCurrentTime = startingSpawnerTime;
            }
        }
    }
}
