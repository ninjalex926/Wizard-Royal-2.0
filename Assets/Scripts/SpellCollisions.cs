﻿using UnityEngine;
using System.Collections;
using UnityEngine;

public class SpellCollisions : MonoBehaviour
{
  

    //  The elemental type for this spell
    [Tooltip(" The elemental type for this spell")]
    public string elementType;

    public GameObject player;

    public GameObject steamObj;

    private Transform trans;

    public ABC_StateManager stateManager;

    private TerrainDetector td;

    public GameObject tree;

    public bool isTreeFire;

    public void Start()
    {
            player = GameObject.FindWithTag("Player");

            stateManager = player.GetComponent<ABC_StateManager>();         
    }

    /// <summary>
    /// Player stays in contact with spell
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (elementType == "Fire")
            {
                if(isTreeFire)
                {
                    if (tree.GetComponent<FireScript>().isBurning)
                    {
                        player.GetComponent<ABC_StateManager>().AdjustHealth(-0.1f);
                        print("Player is COLLDING DO DAMAGE");
                    }
                }
                else
                {
                    player.GetComponent<ABC_StateManager>().AdjustHealth(-0.1f);
                    print("Player is COLLDING DO DAMAGE");
                }
            }
        }

        if (other.gameObject.tag.Equals("Enemy"))
        {
            if (elementType == "Fire")
            {
                if (isTreeFire)
                {
                    if (tree.GetComponent<FireScript>().isBurning)
                    {
                        other.gameObject.GetComponent<ABC_StateManager>().AdjustHealth(-0.1f);
                    }
                }
            }
        }
    }

    //------------------------------------------------------
    // // Contact with other Spells By On Trigger Enter    
    //-----------------------------------------------------------
    public void OnTriggerEnter(Collider other)
    {
        //---------------------------------------------
        //  Colliding with a Tree or Grass
        //-------------------------------------------
        if (other.gameObject.tag.Equals("Tree")  || other.gameObject.tag.Equals("Grass"))
        {
            if (other.gameObject.GetComponent<FireScript>().isBurning)
            {
                if (elementType == "Fire")
                {
                    other.gameObject.GetComponent<FireScript>().FireDuration += 10f;
                }

                if (elementType == "Water")
                {
                    other.gameObject.GetComponent<FireScript>().StopBurning();
                    other.gameObject.GetComponent<FireScript>().StartSmoke();
                }
            }
            else
            {
                if (elementType == "Fire")
                {
                    other.gameObject.GetComponent<FireScript>().fireObj.SetActive(true);
                    other.gameObject.GetComponent<FireScript>().StartFire();
                    other.gameObject.GetComponent<FireScript>().StartSmoke();
                }

                if (elementType == "Water")
                {
                    print("TREE WET");
                }
            }
    }

        //---------------------------------------------
        //  Colliding with Spells
        //-------------------------------------------
        if (other.gameObject.tag.Equals("FireSpell"))
        {
            if (elementType == "Fire")
            {
                print("Increase Fire");
            }

            if (elementType == "Water")
            {

             //   Destroy(other.gameObject);

                float x = this.gameObject.transform.position.x;

                float y = this.gameObject.transform.position.y;

                float z = this.gameObject.transform.position.z;

                Instantiate(steamObj, new Vector3(x, y, z), Quaternion.identity);

            }
        }
    }
}
