/*This script created by using docs.unity3d.com/ScriptReference/MonoBehaviour.OnParticleCollision.html*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitEffectInstance : MonoBehaviour
{
    public GameObject[] EffectsOnCollision;
    public float DestroyTimeDelay = 5;
    public bool UseWorldSpacePosition;
    public float Offset = 0;
    public Vector3 rotationOffset = new Vector3(0,0,0);
    public bool useOnlyRotationOffset = true;
    public bool UseFirePointRotation;
    public bool DestoyMainEffect = true;
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    private ParticleSystem ps;

  [SerializeField]  private SpellStats spellStats;

    [SerializeField] private GameObject selfGameObject;

    public GameObject effectVfx1;

    public GameObject effectVfx2;

    private int hitEffectNum;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }


    void OnParticleCollision(GameObject other)
    {      
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);     
        for (int i = 0; i < numCollisionEvents; i++)
        {
            foreach (var effect in EffectsOnCollision)
            {
                var instance = Instantiate(effect, collisionEvents[i].intersection + collisionEvents[i].normal * Offset, new Quaternion()) as GameObject;
                if (!UseWorldSpacePosition) instance.transform.parent = transform;
                if (UseFirePointRotation) { instance.transform.LookAt(transform.position); }
                else if (rotationOffset != Vector3.zero && useOnlyRotationOffset) { instance.transform.rotation = Quaternion.Euler(rotationOffset); }
                else
                {
                    instance.transform.LookAt(collisionEvents[i].intersection + collisionEvents[i].normal);
                    instance.transform.rotation *= Quaternion.Euler(rotationOffset);
                }
                Destroy(instance, DestroyTimeDelay);
            }
        }



        if (DestoyMainEffect == true)
        {
            Destroy(gameObject, DestroyTimeDelay + 0.5f);
        }

        //-----------------------------------------------------------------------
        //  Hit Effect Based on Spell and Particle Collison
        //-----------------------------------------------------------------------

        //  Fire Collides with Fire
        //  Effects:
        //  Increase Fire Time
        if (other.gameObject.tag.Equals("FireSpell"))
        {
            //  Fire Made Contact with Fire
            if (spellStats.elementType == "Fire")
            {
                print("Fire Hit Fire");
                print("DECREASE Flame time");
                spellStats.timer -= spellStats.increaseTimer;
            }

            //  Water Made Contact with Fire
            if (spellStats.elementType == "Water")
            {
                print("Water Hit Fire");
                print("DECREASE Flame time");
                spellStats.timer -= spellStats.increaseTimer;
            }
        }

        //  Fire Collides with  Water -> Fire
        //  Effects:
        //  Decrease Fire Time
        if (other.gameObject.tag.Equals("WaterSpell"))
        {

            //  Water Hit Water
            if (spellStats.elementType == "Water")
            {
                // Increase Water Volume
                print("Water Hit Water");
            }

            //  Fire Hit Water
            if (spellStats.elementType == "Fire")
            {
                // Increase Water Volume
                print("Water Hit Water");
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //-----------------------------------------------------------------------
        //  Hit Effect Based on Triggers
        //-----------------------------------------------------------------------

        //  Fire Collides with Fire
        //  Effects:
        //  Increase Fire Time
        if (other.gameObject.tag.Equals("FireSpell"))
        {
            //  Fire Made Contact with Fire
            if (spellStats.elementType == "Fire")
            {
                print("Fire Hit Fire");
                print("DECREASE Flame time");
                spellStats.timer -= spellStats.increaseTimer;
            }

            //  Water Made Contact with Fire
            if (spellStats.elementType == "Water")
            {
                print("Water Hit Fire");
                print("DECREASE Flame time");
                spellStats.timer -= spellStats.increaseTimer;
            }


        }

        //  Fire Collides with  Water -> Fire
        //  Effects:
        //  Decrease Fire Time
        if (other.gameObject.tag.Equals("WaterSpell"))
        {

            //  Water Hit Water
            if (spellStats.elementType == "Water")
            {
                // Increase Water Volume
                print("Water Hit Water");
            }

            //  Fire Hit Water
            if (spellStats.elementType == "Fire")
            {
                // Increase Water Volume
                print("Water Hit Water");
            }
        }




    }
}
