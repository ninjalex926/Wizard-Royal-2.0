using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectInstance2 : MonoBehaviour
{
    [HideInInspector] private Rigidbody rb;                           // Rigidbody variable to hold a reference to our projectile prefab
                                                                      // Transform variable to hold the location where we will spawn our projectile
    [SerializeField] private ParticleSystem part;

    [SerializeField] private SpellStats spellStats;

    [SerializeField] private GameObject selfGameObject;

    [SerializeField] private GameObject fireHitEffect;

    [SerializeField] private GameObject waterHitEffect;

    [SerializeField] private GameObject smokeHitEffect;

    public bool hasHitEffect;

    [Tooltip("If False Hit is Triggered by Particle Collision")]
    public bool triggerByOnEnter;


    [Tooltip("If False Hit is Triggered by Particle Collision")]
    public bool triggerByOnParticleCollison;

    [Tooltip("If False Hit is Triggered by Particle Collision")]
    public bool triggerByOnParticleTrigger;


    private void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Trigger Hit Effect by particle Collision
    /// </summary>
    /// <param name="other"></param>
    public void OnParticleCollision(GameObject other)
    {
        if(triggerByOnParticleCollison)
        {
            //  Create Hit Effect
            if (hasHitEffect)
            {
                //-----------------------------------
                //  If the user's Spell is Fire Type
                //-----------------------------------
                if (spellStats.elementType == "Fire")
                {
                    //  Fire Hit Fire
                    if (other.tag == "FireSpell")
                    {
                        print("ParticleCollison - NO EFFECT");
                        // No Hit Effect
                    }

                    //  Fire Hit Water
                    if (other.tag == "WaterSpell")
                    {
                        print("ParticleCollison - SMOKE EFFECT");
                        Instantiate(smokeHitEffect, gameObject.transform.position, transform.rotation);
                    }

                    //  Fire Hit An Enemy
                    if (other.tag == "Enemy")
                    {
                        print("ParticleCollison - FIRE EFFECT");
                        Instantiate(fireHitEffect, gameObject.transform.position, transform.rotation);
                    }
                    //  FIre  Hit Something else
                    else
                    {
                        print("ParticleCollison - FIRE EFFECT");
                        Instantiate(fireHitEffect, gameObject.transform.position, transform.rotation);
                    }
                }


                //-----------------------------------
                //  If the user's Spell is Water
                //-----------------------------------
                if (spellStats.elementType == "Water")
                {
                    //  Water Hit Fire
                    if (other.tag == "FireSpell")
                    {
                        print("ParticleCollison - Smoke EFFECT");
                        Instantiate(smokeHitEffect, gameObject.transform.position, transform.rotation);
                    }

                    //  Water Hit Water
                    if (other.tag == "WaterSpell")
                    {
                        print("ParticleCollison - WATER EFFECT");
                        Instantiate(waterHitEffect, gameObject.transform.position, transform.rotation);
                    }

                    // Water Hit Enemy
                    if (other.tag == "Enemy")
                    {
                        print("ParticleCollison - WATER EFFECT");
                        Instantiate(waterHitEffect, gameObject.transform.position, transform.rotation);
                    }

                    // Water Hit Somethig else
                    else
                    {
                        print("ParticleCollison- WATER EFFECT");
                        Instantiate(waterHitEffect, gameObject.transform.position, transform.rotation);
                    }
                }
            }
        }

    }



    //  Find what collided
    private void OnTriggerEnter(Collider other)
    {
        if(triggerByOnEnter)
        {
            //  Create Hit Effect
            if (hasHitEffect)
            {
                //-----------------------------------
                //  If the user's Spell is Fire Type
                //-----------------------------------
                if (spellStats.elementType == "Fire")
                {
                    //  Fire Hit Fire
                    if (other.tag == "FireSpell")
                    {
                        print("TRIGGER ENTER - NO EFFECT");
                        // No Hit Effect
                    }

                    //  Fire Hit Water
                    if (other.tag == "WaterSpell")
                    {
                        print("TRIGGER ENTER - SMOKE EFFECT");
                        Instantiate(smokeHitEffect, gameObject.transform.position, transform.rotation);
                    }

                    //  Fire Hit An Enemy
                    if (other.tag == "Enemy")
                    {
                        print("TRIGGER ENTER - FIRE EFFECT");
                        Instantiate(fireHitEffect, gameObject.transform.position, transform.rotation);
                    }
                    //  FIre  Hit Something else
                    else
                    {
                        print("TRIGGER ENTER - FIRE EFFECT");
                        Instantiate(fireHitEffect, gameObject.transform.position, transform.rotation);
                    }
                }


                //-----------------------------------
                //  If the user's Spell is Water
                //-----------------------------------
                if (spellStats.elementType == "Water")
                { 
                        //  Water Hit Fire
                        if (other.tag == "FireSpell")
                        {
                        print("TRIGGER ENTER - Smoke EFFECT");
                        Instantiate(smokeHitEffect, gameObject.transform.position, transform.rotation);
                        }

                        //  Water Hit Water
                        if (other.tag == "WaterSpell")
                        {
                            print("TRIGGER ENTER - WATER EFFECT");
                            Instantiate(waterHitEffect, gameObject.transform.position, transform.rotation);
                        }

                        // Water Hit Enemy
                        if (other.tag == "Enemy")
                        {
                        print("TRIGGER ENTER - WATER EFFECT");
                        Instantiate(waterHitEffect, gameObject.transform.position, transform.rotation);
                        }

                        // Water Hit Somethig else
                        else
                        {
                        print("TRIGGER ENTER - WATER EFFECT");
                        Instantiate(waterHitEffect, gameObject.transform.position, transform.rotation);
                        }                  
                }

            }
        }

    }
}
