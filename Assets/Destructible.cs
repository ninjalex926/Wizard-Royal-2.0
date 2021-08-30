/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:     November 1st, 2020
//
//  Brief Description: 
//    This script spawns in a destructable game object when the player
//    hits the game object.
/******************************************************************/
//  It does the following:
//  Spawns in destroyed game object
//  Spawns in item drops
//  Checks to see if the item is a crate or creacked wall/floor
//  Sets how fast the player needs to be to break a game object
// --------------------------------------
using UnityEngine;

public class Destructible : MonoBehaviour {

    //  How fast should the plauer be to break the object
    [Tooltip(" How fast should the plauer be to break the object")]
    public float neededVelocity;

    // Referance to the player object
    [Tooltip("  Referance to the player object rigidbody")]
    public GameObject playerRB;

    // Reference to the shattered version of the object
    [Tooltip("The amount of hits needed to activate the crystal")]
    public GameObject destroyedVersion;

    // Reference to a first item drop
    [Tooltip("Item Drop 1")]
    public GameObject itemDrop1;

    // Reference to a seconed item drop
    [Tooltip("Item Drop 2")]
    public GameObject itemDrop2;

    // Reference to a seconed item drop
    [Tooltip("Explosion Game Object")]
    public GameObject Explosion;

    //  Spawns in a drop based on its index
    private int prize_Number;

    // Is the game object a cracked wall or floor
    [Tooltip("Is the game object a cracked wall or floor")]
    public bool isCrackedFloor;


    // Is the game object a Destructable Crate
    [Tooltip("Is the game object a Destructable Crate")]
    public bool isDestructableCrate;

    // Is the game object a Destructable Crate
    [Tooltip("Is the game object an Explosive Crate")]
    public bool isExplosiveCrate;

    private void Start()
    {
        playerRB = GameObject.Find("ControllerV2.1");
    }

    /// <summary>
    /// Checks to see if the player is colliding with the game object.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider collision)
    {
        // Player is hitting the floor with ground pound
        if (isCrackedFloor == true)
        {

        }

        // Player is hitting a box 
        if (isDestructableCrate == true)
        {

            if (collision.gameObject.tag == "MagicSpell" || collision.gameObject.tag == "FireSpell")
            {

                print("COLLIDED");


                // Spawn a shattered object
                Instantiate(destroyedVersion, transform.position, transform.rotation);

                prize_Number = Random.Range(0, 2);

                if(!isExplosiveCrate)
                {
                    switch (prize_Number)
                    {
                        // No Drops
                        case 0:
                            // Give nothing
                            break;
                        // Drops an item
                        case 1:
                            Instantiate(itemDrop1, transform.position, transform.rotation);
                            break;
                        // Drops a Ma
                        case 2:
                            Instantiate(itemDrop2, transform.position, transform.rotation);
                            break;
                    }

                }
                else
                {
                    Instantiate(Explosion, transform.position, transform.rotation);
                }

            

                // Remove the current object
                Destroy(gameObject);
            }
        }
    }
}




