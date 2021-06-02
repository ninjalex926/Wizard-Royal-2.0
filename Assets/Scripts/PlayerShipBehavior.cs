/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:     November 19th, 2020
//
//  Brief Description: This script contains the player's ship 
//  movement and position functions
//  It does the following:
//  Creates the ship's max speed and rotation speed
//  Warps the ship on the opposite side of the screen if it crosses
//  the edge of the screen
/******************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipBehavior : MonoBehaviour
{
    //  Creates player ship header
    [Header("Player's Ship Information")]

    //  Set the max speed of the ship
    [Tooltip("The max speed of the ship")]
    public float maxSpeed = 5f;

    //  Set the max speed of the ship
    [Tooltip("The max speed of the ship")]
    public float currentMaxSpeed;

   public SpriteRenderer sprite;

    public Color shipColor;

    public Color damaged;

    //  Set how fast the ship rotates
    [Tooltip("How fast the ship rotates")]
    public float rotSpeed = 180f;

    //  Set how fast the ship rotates
    [Tooltip("How fast the ship rotates")]
    public float currentRotSpeed;

    //  Reference to the enemy's health bar
    [Tooltip("The enemy's healthbar")]
    public Health_Bar healthbar;

    //  Reference to the text that displays damage
    [Tooltip("The display damage text")]
    public Text damageText;

    //  Reference to the max amount of health the player can have 
    [Tooltip("The max amount of health the player can have")]
    public int maxPlayerHealth;

    //  Reference to the damage the player takes
    [Tooltip("The damage the player takes")]
    public int damage;

    //  Reference to the explosive damage the player takes
    [Tooltip("The explosive damage the player takes")]
    public int explosionDamage;

    //  Reference to the boss damage the player takes
    [Tooltip("The boss damage the player takes")]
    public int bossDamage;

    //  Reference to the players current given health
    [Tooltip("The players current given health")]
    public int currentPlayerHealth;

    public bool tookDamage;

    public float spriteDamageTimer;

    public float currentSpriteDamageTimer;


    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;

        healthbar.SetMaxHealth(maxPlayerHealth);

        currentMaxSpeed = maxSpeed;

        currentRotSpeed = rotSpeed;

        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemylaser")
        {
            tookDamage = true;
            spriteDamageTimer += 0.2f;
            currentPlayerHealth -= damage;
            healthbar.SetHealth(currentPlayerHealth);
        }

        if (collision.gameObject.tag == "enemybomb")
        {
            tookDamage = true;
            spriteDamageTimer += 0.2f;
            currentPlayerHealth -= explosionDamage;
            healthbar.SetHealth(currentPlayerHealth);
        }

        if (collision.gameObject.tag == "bosslaser")
        {
            tookDamage = true;
            spriteDamageTimer += 0.2f;
            currentPlayerHealth -= bossDamage;
            healthbar.SetHealth(currentPlayerHealth);
        }      
    }

    void Update()
    {

        if(spriteDamageTimer > 0)
        {
            spriteDamageTimer -= Time.deltaTime;

            sprite.color = damaged;

        }
        else if(spriteDamageTimer <= 0)
        {
            sprite.color = shipColor;
        }


   

        healthbar.SetHealth(currentPlayerHealth);

        //  Grab the ship's rotation quaternion
        Quaternion rot = transform.rotation;

        //  Grab the Z euler angle of the ship
        float z = rot.eulerAngles.z;

        //  Change the ship's Z angle based on the input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //  Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        //  Input the quaternion into our rotation
        transform.rotation = rot;

        //  Move the ship.
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") 
        * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        //  Update the ship's position
        transform.position = pos;

        //  Check if the ship is on an edge of the screen

        //  Warp the ship from the left to right side of the screen
        if (transform.position.x < -9.0f)
        {
            transform.position = new Vector3(8, transform.position.y);
        }

        //  Warp the ship from the right to the left side of the screen
        if (transform.position.x > 9.0f)
        {
            transform.position = new Vector3(-8, transform.position.y);
        }

        //  Warp the ship from the bottom to the top side of the screen
        if (transform.position.y < -5.0f)
        {
            transform.position = new Vector3(transform.position.x, 5);
        }

        //  Warp the ship from the top to the bottom side of the screen
        if (transform.position.y > 5.0f)
        {
            transform.position = new Vector3(transform.position.x, -5);
        }

        if(currentPlayerHealth <= 0)
        {
       
        }
    }
}

