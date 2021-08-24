/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:     December 13th, 2020
//
//  Brief Description: 
//  Added to spells to control burning
//  Start burning flames
//  Increase Flame time
//  Descrease Flame time
//  Stop burning falmes

/******************************************************************/
using UnityEngine;

public class BurningFlamesTrigger : MonoBehaviour {

    //  The elemental type for this spell
    [Tooltip(" The elemental type for this spell")]
    public string elementType;

    //------------------------------------------------------
    // // Contact with other Spells By On Trigger Enter    
    //-----------------------------------------------------------
    public void OnTriggerEnter(Collider other)
    {
        //---------------------------------------------
        // // Burnable Objects?
        //-------------------------------------------
        if (other.gameObject.tag.Equals("Tree"))
        {
            //   print("TREEEEEEEEEEEEEEEEEEEEE");

            if (elementType == "Fire")
            {
                //   print("Im BURRRRRNNNINGGGGGGGGGGTREEEE!!!!!!!!");
                other.gameObject.GetComponent<FireScript>().StartFire();
            }
        }
    }
}
