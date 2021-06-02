using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFireball : MonoBehaviour
{
    [HideInInspector] private Rigidbody rb;                           // Rigidbody variable to hold a reference to our projectile prefab
                         // Transform variable to hold the location where we will spawn our projectile
     public float projectileForce = 250f;                    // Float variable to hold the amount of force which we will apply to launch our projectiles

    public int damage;

    public float forceHit;

    public ForceMode forceMode;

    public GameObject explosion;

    public bool hasHitEffect;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, projectileForce));
    }

    private void OnTriggerEnter(Collider other)
    {

        if(hasHitEffect)
        {
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
        }

      

        if (other.tag == "Enemy")
        {
            Target target = other.gameObject.transform.GetComponent<Target>();

            target.TakeDamage(damage);

        

            Rigidbody targetRb = other.gameObject.GetComponent<Rigidbody>();

            targetRb.AddForce(0f, 0f, forceHit);
             
        }
    }
}

