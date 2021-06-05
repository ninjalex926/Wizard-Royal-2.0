/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:     December 13th, 2020
//
//  Brief Description: 
//  Holds Spells Values and Deals damage on Collision
//  
//  It does the following:
//  Deals damage to the player on contact 
//  Can deal damage over tine
//  Destroys itself over a timer 
// Can collider with Triggers or Partcle Worl Effects
/******************************************************************/
using UnityEngine;

public class SpellStats : MonoBehaviour {

    //  The amount of damage
    [Tooltip("How much damage the spell deals")]
    public int damage;

    //  The elemental type for this spell
    [Tooltip(" The elemental type for this spell")]
    public string elementType;

    //  Does the damage dealt over time
    [Tooltip("Deal damage over time?")]
    public bool isDamageOverTime;

    //  The effect has a timer
    [Tooltip("Does the effect have a timer?")]
    public bool hasTimer;

    //  Does the damage dealt over time
    [Tooltip("Destoy itself when timer is 0")]
    public float timer;

    //  Increase the durration of the spell by this amount when called
    [Tooltip(" Increase the durration of the spell by this amount when called")]
    public float increaseTimer;

    //  Checks to see if the player is touching the partcle effect
    private bool playerIsTouching = false;

    //  Checks to see if the target is touching the partcle effect
    private bool targetIsTouching = false;

    //  Checks to see if the target is touching the partcle effect
    //   private bool fireIsTouching = false;


    // Rigidbody variable to hold a reference to our projectile prefab
    [HideInInspector] private Rigidbody rb;
    
    // Float variable to hold the amount of force which we will apply to launch our projectiles                                                               
    public float projectileForce = 250f;                   

    public float forceHit;

    public bool hasForce;

    //  The Force Mode
    public ForceMode forceMode;

    //  The Initail Hit Effect 
    private GameObject hitEffect;

    //  The Initail Hit Effect 
    public GameObject[] hitEffectArray;

    //  What Hit Effect to use from the Array
    // 0 = WateHit  = Smoke, 2 = Fire Hit
    public int hitEffectNum;

    //  Does this Game Object have a Hit Effect
    public bool hasHitEffect;

    //  Referance to this Game Object Partcle System
    [Tooltip("Referance to this Game Object Partcle System")]
    public ParticleSystem part;

    //  Can this Game Object Hurt the Player?
    [Tooltip("Can this Game Object Hurt the Player?")]
    public bool hurtPlayer;

    //  Can this Game Object Hurt the Target
    [Tooltip("Can this Game Object Hurt the Target?")]
    public bool hurtTarget;

    //  Referance to the current target
    private Target target;

    //  Referance to Player Stats
    private PlayerStats player;

    //  Check Damage Collison by Collider Trigger or by Particle World Collsion
    // If False use Particle Woeld Collision
    [Tooltip("Check Damage Collison by Collider Trigger or by Particle World Collsion")]
    public bool dealDamageByTrigger;


    /// <summary>
    /// Set the partcile system
    /// </summary>
    private void Start()
    {
        if(hasForce)
        {
            //  Get this Rigidbody
            rb = gameObject.GetComponent<Rigidbody>();

            //  Add force to object
            rb.AddRelativeForce(new Vector3(0, 0, projectileForce));
        }

        part = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Deals damage to the player over time
    /// </summary>
    private void Update()
    {
        if (targetIsTouching && isDamageOverTime)
        {
            target.TakeDamage(damage);
        }


        if (playerIsTouching && isDamageOverTime)
        {
            player.TakeDamage(damage);
        }

        if (hasTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Check if Tagged Game Object is touching the spell 
    /// via entering a Trigger Collider
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if (dealDamageByTrigger)
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
            if (hurtTarget)
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


            // Hurt the target and player
            if (hurtTarget && hurtPlayer)
            {
                // Hurt the enemy
                if (other.gameObject.tag.Equals("Enemy"))
                {
                    target = other.gameObject.transform.GetComponent<Target>();


                    targetIsTouching = true;

                    print("Damage target");


                    if (!isDamageOverTime)
                    {

                        target.TakeDamage(damage);
                    }
                }

                //  Hurt the player
                if (other.gameObject.tag.Equals("Player"))
                {

                    print("Damage player");

                    player = other.gameObject.transform.GetComponent<PlayerStats>();

                    playerIsTouching = true;

                    if (!isDamageOverTime)
                    {
                        player.TakeDamage(damage);

                    }
                }
            }

            //  Increase Fire Time
            if (other.gameObject.tag.Equals("FireSpell"))
            {
                print("contact with fire");

                if (elementType == "Fire")
                {

                    print("INCEREASE Flame time");
                    timer += increaseTimer;
                }
            }
        }
    }

    /// <summary>
    /// Check if Tagged Game Object is touching the spell 
    /// via entering a Particle World Collsion
    /// </summary>
    /// <param name="other"></param>
    void OnParticleCollision(GameObject other)
    {
        //-----------------------------------------------------------------------------
        //  Does it Have Force, or Multi-Hit Effects
        //-----------------------------------------------------------------------------




        // Add Force
        if (hasForce)
        {
            if (other.tag == "Enemy")
            {
                Target target = other.gameObject.transform.GetComponent<Target>();

                Rigidbody targetRb = other.gameObject.GetComponent<Rigidbody>();

                targetRb.AddForce(0f, 0f, forceHit);
            }
        }

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
        if (hurtTarget)
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

        // Hurt the target and player
        if (hurtTarget && hurtPlayer)
        {
            //Damage Enemy
            if (other.gameObject.tag.Equals("Enemy"))
            {
                target = other.gameObject.transform.GetComponent<Target>();


                targetIsTouching = true;

                print("Damage target");


                if (!isDamageOverTime)
                {

                    target.TakeDamage(damage);
                }
            }
            //  Damage the Player
            if (other.gameObject.tag.Equals("Player"))
            {

                print("Damage player");

                player = other.gameObject.transform.GetComponent<PlayerStats>();

                playerIsTouching = true;

                if (!isDamageOverTime)
                {
                    player.TakeDamage(damage);

                }
            }
        }

        //-----------------------------------------------------------------------
        //  Check Spell Collision with other Spells
        //-----------------------------------------------------------------------

        //  Fire Collides with Fire
        //  Effects:
        //  Increase Fire Time
        if (other.gameObject.tag.Equals("FireSpell"))
        {
            print("fire made contact with fire");

            hitEffectNum = 2;

            if (elementType == "Fire")
            {
                print("INCEREASE Flame time");
                timer += increaseTimer;
            }
        }

        //  Fire Collides with Water/ Water -> Fire
        //  Effects:
        //  Increase Fire Time
        if (other.gameObject.tag.Equals("WaterSpell"))
        {

            hitEffectNum = 1;

            print("water made contact with fire");

            if (elementType == "Fire")
            {
                print("DECREASE Flame time");
                timer -= increaseTimer;
            }
        }


        //  Water Collides with Fire/ Water -> Fire
        //  Effects:
        //  Increase Fire Time
        if (other.gameObject.tag.Equals("FireSpell"))
        {
            print("fire made contact with water");

            hitEffectNum = 1;

            if (elementType == "Water")
            {
                print("DECREASE Flame time");

                other.gameObject.GetComponent<SpellStats>().timer -= increaseTimer;
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
        else if (elementType == "Fire" && other.gameObject.tag.Equals("FireSpell"))
        {
            //      fireIsTouching = false;
        }
    }
}
