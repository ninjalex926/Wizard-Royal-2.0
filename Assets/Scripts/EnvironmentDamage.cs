﻿/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:     December 13th, 2020
//
//  Brief Description: 
//  Handles envoirmental damage
//  
//  It does the following:
//  Deals damage to the player on contact 
//  Can deal damage over tine
//  Destroys itself over a timer 
/******************************************************************/
using UnityEngine;

// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(Collider))]

public class EnvironmentDamage : MonoBehaviour {

    //  The amount of damage
    [Tooltip("Damage Dealt")]
    public int damage;

    public string damagetype;

    //  Does the damage dealt over time
    [Tooltip("Deal damage over time?")]
    public bool isDamageOverTime;

    //  The effect has a timer
    [Tooltip("Does the effect have a timer")]
    public bool hasTimer;

    //  Does the damage dealt over time
    [Tooltip("Destoy itself when timer is 0")]
    public float timer;

    public float increaseTimer;

    //  Checks to see if the player is touching the partcle effect
    private bool playerIsTouching = false;

    //  Checks to see if the target is touching the partcle effect
    private bool targetIsTouching = false;

    //  Checks to see if the target is touching the partcle effect
 //   private bool fireIsTouching = false;

    public bool hurtPlayer;

    public bool hurtTarget;

    private Target target;

    private PlayerStats player;


    /// <summary>
    /// Deal damage to the player if they are touching the particle effect
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Hurt the player
        if (hurtPlayer)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                player = other.gameObject.transform.GetComponent<PlayerStats>();

                playerIsTouching = true;

                if (!isDamageOverTime)
                {
                    player.TakeDamage(damage);
                }
            }
        }
        // Hurt the target
        else if (hurtTarget)
        {
            if (other.gameObject.tag.Equals("Enemy"))
            {
                target = other.gameObject.transform.GetComponent<Target>();

                targetIsTouching = true;

                if (!isDamageOverTime)
                {
                    target.TakeDamage(damage);
                }
            }
        }
        // Doesn't Hurt anyone
        else
        {

        }





        if (other.gameObject.tag.Equals("FireSpell"))
        {
            print("contact with fire");

            if (damagetype == "Fire")
            {

    
                print("INCEREASE Flame time");
                timer += increaseTimer;
            }
        }
    }

    /// <summary>
    /// Deals damage to the player over time
    /// </summary>
    private void Update()
    {
        if(targetIsTouching && isDamageOverTime)
        {
            target.TakeDamage(damage);
        }
        else if(playerIsTouching && isDamageOverTime)
        {
            player.TakeDamage(damage);
        }

        if(hasTimer)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// If the player is not touching the effect set it
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            targetIsTouching = false;
        }
        else if (other.gameObject.tag.Equals("Player"))
        {
            playerIsTouching = false;
        }
        else if (damagetype == "Fire" && other.gameObject.tag.Equals("FireSpell"))
        {
      //      fireIsTouching = false;
        }
    }
}
