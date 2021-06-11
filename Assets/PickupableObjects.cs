using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObjects : MonoBehaviour
{

    public GameObject playerRef;

    public int healthRestore;

    public int manaRestored;

    public int fireManRestored;

    public bool healPlayer;

    public bool restorePlayerMana;

    public bool restorePlayerFireMana;

    public bool destroyOnTrigger;

  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RestorePlayerHealth(int healthRestore)
    {
        playerRef.GetComponent<PlayerStats>().currentPlayerHealth += healthRestore;
    }

    public void RestorePlayerMana(int manaRestored)
    {
        playerRef.GetComponent<PlayerStats>().currentPlayerMana += manaRestored;
            
    }

    public void RestorePlayerFireMana(int fireManRestored)
    {
        playerRef.GetComponent<PlayerStats>().currentFirePlayerMana += fireManRestored;
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }


    /// <summary>
    /// When Object collides with object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // If t collides with player
        if (other.tag == "Player")
        {
            if(healPlayer)
            {
                RestorePlayerHealth(healthRestore);

                if (destroyOnTrigger)
                {
                    DestroySelf();
                }
            }

            if(restorePlayerMana)
            {
                RestorePlayerMana(manaRestored);

                if (destroyOnTrigger)
                {
                    DestroySelf();
                }
            }

            if(restorePlayerFireMana)
            {
                RestorePlayerFireMana(fireManRestored);

                if(destroyOnTrigger)
                {
                    DestroySelf();
                }
               
            }
        }
    }
}
