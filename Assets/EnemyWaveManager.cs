using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class EnemyWaveManager : MonoBehaviour
{
    public ABC_StateManager player_ABCSM;

    // public ABC_StateManager enemy_ABCSM;

    public bool battleActive;

  //  public GameObject[] enemyGroups;

    // The current number of waves
    public int waveNum;

    // How many enmies need to be killed to win
    public int waveKCGoal;

    // How many emies have been killed
    public int currentKC;

    // How many enemies are currently in the map
    public int activeEnemiesNum;

    public GameObject[] activeEnemies;

    public Text waveNumText;

    public Text waveGoalText;

    public GameObject winText;

    public GameObject loseText;

    public void Start()
    {
        //  Get the number of Active aenmies
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in activeEnemies)
        {
            activeEnemiesNum += 1;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }


        waveNumText.text = ("Wave:" + "" + waveNum);

        waveGoalText.text = ("Kill Count" + "" + currentKC + "/" + waveKCGoal);



        // If Player Health reaches 0, You lose
        if (player_ABCSM.currentHealth <= 0)
        {
            print("YOU LOSE");

            winText.SetActive(true);

            //   SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }


        // if Player kills amount needed to wun the wave
        if(currentKC >= waveKCGoal)
        {
            winText.SetActive(true);

            print("YOU Win");
        }


    }

   public void IncreaseKC()
    {
        ++currentKC;
    }

}
