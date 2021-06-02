/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:     December 6th, 2020
//
//  Brief Description: 
//  Holds the healthbar UI information  
//
//  It does the following:
//  Gets the enemy's current and max health
//  Connects the health to the UI health bar
/******************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class Mana_Bar : MonoBehaviour
{
    //  Creates referance for big asteroid
    [Tooltip("The mana bar UI object")]
    public Slider slider;


    /// <summary>
    /// Sets the max health from the enemy to slider
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    /// <summary>
    /// Sets the current health from the enemy to slider
    /// </summary>
    /// <param name="health"></param>
    public void SetMana(int mana)
    {
        slider.value = mana;
    }
}
