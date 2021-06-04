using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavoir : MonoBehaviour
{
    [HideInInspector] private Rigidbody rb;                           // Rigidbody variable to hold a reference to our projectile prefab
                         // Transform variable to hold the location where we will spawn our projectile
     public float projectileForce = 250f;                    // Float variable to hold the amount of force which we will apply to launch our projectiles



    public float forceHit;

    public ForceMode forceMode;

    public GameObject explosion;

    public bool hasHitEffect;

    private void Start()
    {
        //  Get this Rigidbody
        rb = gameObject.GetComponent<Rigidbody>();

        //  Add force to object
        rb.AddRelativeForce(new Vector3(0, 0, projectileForce));
    }

    
    //  Find what collided
    private void OnTriggerEnter(Collider other)
    {

        //  Create Hit Effect
        if (hasHitEffect)
        {
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
        }

      
        // Add Force
        if (other.tag == "Enemy")
        {
            Target target = other.gameObject.transform.GetComponent<Target>();

            Rigidbody targetRb = other.gameObject.GetComponent<Rigidbody>();

            targetRb.AddForce(0f, 0f, forceHit);
             
        }
    }
}

