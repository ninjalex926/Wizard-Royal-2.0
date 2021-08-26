using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseCon : MonoBehaviour
{
  public  ABC_StateManager player_ABCSM;

  public ABC_StateManager enemy_ABCSM;

   

 

    // Update is called once per frame
    void Update()
    {
        

        if(player_ABCSM.currentHealth <= 0)
        {
            print("YOU LOSE");
        }

      

        if (enemy_ABCSM.currentHealth <= 0)
        {
            print("YOU Win");
        }


       //    print(enemy_ABCSM.currentHealth);

     //    print(player_ABCSM.healthABC);
    }
}
