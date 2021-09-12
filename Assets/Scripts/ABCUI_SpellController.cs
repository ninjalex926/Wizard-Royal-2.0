using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCUI_SpellController : MonoBehaviour
{



    public GameObject playerRef;

    public GameObject UI_BookSpell_Icon;

    public ABC_Controller abcCon;

    public ABC_Ability nullbullet;

     int nullboltID = 1123773;

    public string nullbulletStr;

    public bool isAbilityEnabled;

  //  public ABC_IEntity abcIE;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");

        abcCon = playerRef.GetComponent<ABC_Controller>();

        nullbullet = abcCon.FindAbility(1123773);

        nullbullet.abilityEnabled = true;



        //  print(nullbullet.name);

    }
}
