using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar_Icon : MonoBehaviour
{

    public GameObject abilityIcon1;

    public GameObject abilityIcon2;

    public GameObject abilityIcon3;

    public int activeAbility;

    //   public Image iconImage;

    //    public Sprite spriteIcon;

    //   public GameObject iconObject;

    //    public GameObject playerWeapon;

    //    public bool isActive;


    public void Start()
    {       


    }

    public void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if(activeAbility != 1)
            {

            }
        }

    }
}
