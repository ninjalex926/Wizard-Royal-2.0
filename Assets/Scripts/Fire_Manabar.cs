/******************************************************************
//  Author:            Alex Cowell
//  Creation Date:   
//

/******************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class Fire_Manabar : MonoBehaviour
{
    //  Creates referance for big asteroid
    [Tooltip("The fire mana bar UI object")]
    public Slider slider;


    /// <summary>
    /// Sets the max health from the enemy to slider
    /// </summary>
    /// <param name="health"></param>
    public void SetMaxFireMana(int fireMana)
    {
        slider.maxValue = fireMana;
        slider.value = fireMana;
    }

    /// <summary>
    /// Sets the current health from the enemy to slider
    /// </summary>
    /// <param name="health"></param>
    public void SetFireMana(int fireMana)
    {
        slider.value = fireMana;
    }
}
