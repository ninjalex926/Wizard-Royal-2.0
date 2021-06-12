using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPage : MonoBehaviour
{

    public Sprite spriteIcon;

    public GameObject spellObject;

    public GameObject playerWeapon;

    public Image iconImage;

 
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("COLLIDNG with PLAYER");

            if (Input.GetKeyDown("5"))
            {

                print("MAKE ABILITY SLOT 1 FIREBALL");

                playerWeapon.GetComponent<SpellCastingBehaviour>().spellObject = spellObject;

                  iconImage.sprite = spriteIcon;
            }
        }
    }
}
