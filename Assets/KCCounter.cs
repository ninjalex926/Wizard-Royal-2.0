using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCCounter : MonoBehaviour
{

    public GameObject waveManager;

    public ABC_StateManager enemyABCSM;



    // Start is called before the first frame update
    void Start()
    {
         waveManager = GameObject.FindGameObjectWithTag("WaveManager");
    }

    // Update is called once per frame
    void Update()
    {


        // If Player Health reaches 0, You lose
        if (enemyABCSM.currentHealth <= 0)
        {
            print("ENMEY HEALTH 0 Increase socre");
            waveManager.GetComponent<EnemyWaveManager>().IncreaseKC();
            Destroy(gameObject.GetComponent<KCCounter>());
        }

    }
}
